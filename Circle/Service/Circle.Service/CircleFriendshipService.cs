using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class FriendRequest
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public FriendRequestStatus Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public enum FriendRequestStatus
{
    Pending,
    Accepted,
    Rejected
}

public class ApplicationDbContext : DbContext
{
    public DbSet<FriendRequest> FriendRequests { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FriendRequest>()
            .HasKey(fr => fr.Id);
    }
}

public interface IFriendRepository
{
    Task AddFriendRequestAsync(FriendRequest request);
    Task<List<FriendRequest>> GetFriendRequestsAsync(int userId);
    Task<FriendRequest> GetFriendRequestByIdAsync(int id);
    Task UpdateFriendRequestAsync(FriendRequest request);
    Task DeleteFriendRequestAsync(int id);
}

public class FriendRepository : IFriendRepository
{
    private readonly ApplicationDbContext _context;

    public FriendRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddFriendRequestAsync(FriendRequest request)
    {
        await _context.FriendRequests.AddAsync(request);
        await _context.SaveChangesAsync();
    }

    public async Task<List<FriendRequest>> GetFriendRequestsAsync(int userId)
    {
        return await _context.FriendRequests
            .Where(fr => fr.ReceiverId == userId && fr.Status == FriendRequestStatus.Pending)
            .ToListAsync();
    }

    public async Task<FriendRequest> GetFriendRequestByIdAsync(int id)
    {
        return await _context.FriendRequests.FirstOrDefaultAsync(fr => fr.Id == id);
    }

    public async Task UpdateFriendRequestAsync(FriendRequest request)
    {
        _context.FriendRequests.Update(request);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFriendRequestAsync(int id)
    {
        var request = await GetFriendRequestByIdAsync(id);
        if (request != null)
        {
            _context.FriendRequests.Remove(request);
            await _context.SaveChangesAsync();
        }
    }
}

public class FriendService
{
    private readonly IFriendRepository _repository;

    public FriendService(IFriendRepository repository)
    {
        _repository = repository;
    }

    public async Task SendFriendRequest(int senderId, int receiverId)
    {
        var request = new FriendRequest
        {
            SenderId = senderId,
            ReceiverId = receiverId,
            Status = FriendRequestStatus.Pending
        };
        await _repository.AddFriendRequestAsync(request);
    }

    public async Task<List<FriendRequest>> ViewFriendRequests(int userId)
    {
        return await _repository.GetFriendRequestsAsync(userId);
    }

    public async Task AcceptFriendRequest(int requestId)
    {
        var request = await _repository.GetFriendRequestByIdAsync(requestId);
        if (request != null && request.Status == FriendRequestStatus.Pending)
        {
            request.Status = FriendRequestStatus.Accepted;
            await _repository.UpdateFriendRequestAsync(request);
        }
    }

    public async Task CancelFriendRequest(int requestId)
    {
        await _repository.DeleteFriendRequestAsync(requestId);
    }
}
