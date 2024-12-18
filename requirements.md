# Social Media - Assignment

# Overview

A social media platform with fully functional capabilities to have friends, followers, a feed filled with friends’ and followers’ posts and recommendations based on the user's interests, targeted at a particular audience with separation on niche interests. For example, an audience such as developers(audience) with front end(niche), artists(audience) with interest in airplane paper drawings(niche), construction workers(audience) building big residences(niche), etc.


# Main Entities

Users
Posts
Comments
Reactions
Messages (chat)


# Notable Features

## User Registrations
Users must be able to register and verify their registration by email. Users mustn’t have permissions to post, like or comment, if their account is not verified. A user must be presented with the option to accept Terms and Conditions (T&C) and be unable to complete registration without accepting the T&C. T&C could be a “lorem ipsum” type of text. 

## User Login/Logout
A user must have the ability to login into the website after registering or if he has logged out. Users must have the option to use either email or username and password for login. A “remember me” functionality must exist.

## User Deletion
Users must have access to delete their data from the website and invalidate further actions, such as posting, liking, following. User’s posts can be conditionally deleted, as per posts’ owner’s preference.

## User Profile
Every user must have a user profile page with the required username, email, and optional profile picture settings and all the posts they have posted.The user must also have the option to change his/hers password. The user’s profile picture must be present somewhere in the user’s feed page, as a quick link to the user’s profile page. One user must be able to open another user’s profile page.

## User Feed
Every user must have a custom feed, based on their friends and who they follow. Posts from friends and followed users must have priority over other posts in the feed. Optionally, the feed can have posts from friends’s friends of the current user.users in the current user’s. 

## User Request
A user must have the option to send a friend request to another user and the other user must have the option to accept or reject the friend request.

## Followers
A user can optionally follow another user. That means the former can view the latter’s posts with higher priority without the need to send a friend request. 

## Administration
A group of users must have the capabilities to administer the website and guard from harmful content. Every user from that group must go through a verification process before having admin privileges. Admin must have the ability to delete posts. An admin must have some kind of visual effect on the front end to indicate he/she has admin privileges (for example, different border over profile picture).

## Email Verification
Users must approve the account, in order to gain sufficient permissions to do more actions on the website. 

## Posts
A post could contain images and/or links to external resources. The image(s) must be after the text of the post and must be scrollable optionally left and right (as opposed to having all/most of the images cluttered at one, as it’s on Facebook). Visualization of only one image at a time is required. A link to an external website must yield a warning of some sort like “potential dangerous website” upon clicking.

## Privacy
A user should be capable of configuring who sees his posts and who can comment on his posts. 

## Post Deletion
Users must have the ability to delete posts and optionally to recover them from deletion. A deleted post should only show up in the user’s profile page and it shouldn’t appear in other user’s feeds.

## Tagging users
Upon posting, a user can tag another user. A tagged user has the option to remove himself/herself from being tagged, but shouldn’t be able to remove other users or delete the post. The post’s owner can also, optionally, remove a tagged user and add new ones. Tagged users must be visualized in some way on the post. Clicking on a tagged user should redirect you to his/hers profile.

## Tags
A flag can have optional flags, similar to hashtags in Facebook. Tags must be visualized either at the very bottom of the post, under the image, or at the very top of the post. Tags must be distinguishable from the post’s text (smaller font, different color, for example). Tags should be small enough to not disturb post’s text and big enough to be clickable. Clicking on a tag will redirect you to the search functionality with the tag prepopulated in the search field.

## Search
A user must have the ability to search for friends, other users and posts and posts with the specified tags. Users that are already friends must be denoted with different visual elements from other users (for example a different background color, a grayed out button that says “already a friend”, etc). The search order must be exact match first, then fuzzy search and users, then posts, then posts with the searched tags.

## Notifications
A user should receive notifications about being tagged, having a comment on one of his posts, post reactions, getting a friend request, being followed etc. and any action that affects them directly. 

## Messaging (chat)
Users should be capable of communicating through chat-based functionality in real-time. Messages should be kept in an encrypted format as history.

# Nice to have functionality

## Two-factor authentication

## User blocking

