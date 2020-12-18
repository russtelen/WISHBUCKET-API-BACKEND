# NET Project Team 6 💠

- Fatma
- Stefan
- Nicholas
- Vlad
- Russ

A public version of the API is published at https://giftwishlist1.azurewebsites.net/ The root url provides the swagger documentation for the api routes.

# Wishbucket - Easy Wishlists

Elevator Pitch:
A lightweight application with a slick look and feel featuring shareable wishlists in an easy breeze. Quickly create a wishlist for yourself or someone else, and share it with others - the days of unwanted or duplicated gifts are over!

#### Front-End Project:

https://github.com/russtelen/WISHBUCKET

### Figma Wireframe

Figma URL: https://www.figma.com/file/qOWCw5hQsP4Xu5bkBxXUcq/WishBucket?node-id=0%3A1

![WFM](https://i.imgur.com/KQBOscC.jpg)

## Project Reqs 📋

#### Design Req

- Need a nice and **detailed** README as per NET proj repo

#### Build Req

- Implement and **maintain** Kanban board in GH
  - Tasks/Backlogs broken into **small issues**
- Branches
  - commits should be **related to an issue**
  - make **frequent** commits
  - video call on **Pull Requests**
- Maintain clean code
  - remove **unnecassary** comments
  - indentations
  - **descriptive** class names and functions

#### Communication Req

- Stand up meetings **daily**
- If you **cant** make the meetings, post in **Slack** the following daily:
  - what you did
  - what you will do next
  - blockers
- If you cant meet a deadline, **let the team know ASAP** so we can help each other

## API vs Razor vs MVC 🔪

- API is easier
  - less NET code

## Use Case Diagram (UCD)

![UCD](https://i.imgur.com/TtijKPC.jpg)

## Entity Relationship Diagram (ERD)

![ERD](https://i.imgur.com/htCdxTe.png)

# Requirements

## Functional

- User Accounts
- Wishlists (CRUD)
- Items (CRUD)
- Item status (fulfilled/pending)
- Link sharing

## Non-Functional

- List of all wishlists (dashboard)
- List the items in a wishlist
- Wishlist filtered by date

# Features

## Must-have

- Authentication
- Database
- Sort wishlists by active/inactive, then date

## Nice-to-have

- User Groups
- Private/Public wishlists
- Search public wishlists
- Due date notifications
- Item status notification
- Security (recaptcha, login request delay, user password requirements)

# Installation Instructions

The app requires appsettings.json to follow the format provided in the `appsettingsTEMPLATE.json` file placed in the project folder. The app also requires a running SQL or Azure SQL instance that the app can be connected to. Before running the app the `WishContext` and `AuthContext` migrations have to be run in order to configure the required tables, and the default seed data.

The app requires the user secrets to follow the format provided in the `secretsTEMPLATE.json` file placed in the project folder.
In order for the authentication to function the `JWT_SITEKEY` has to be at least 16 characters long, and `JWT_ISSUER` has to be set to the url that the app is running on

## Replicating the migrations
The necessary migrations for AuthContext and WishContext are already included with the project. However, the following steps can replicate it 

```
Add-Migration -Context AuthContext
Add-Migration -Context WishContext
Update-Database -Context AuthContext
Update-Database -Context WishContext
```


# Timeline 🕗

- Dec 5 :
  - Brainstorm app :heavy_check_mark:
    - **_Top 3 Brainstormed App_**
      - **Gift Wishlist App**
        - User Creates an Account
        - Any one user create, update , delete a "Group Of Users" (Ex: Secret Santa with your group of friends, or group of family or group of classmates etc etc etc.)
        - Group contains Users
        - User can create, update, delete wishlist
        - Wishlist contains list of wishes
      - **HR App**
        - One auth user -> HR Manager
        - HR creates, update, view, delete Departments
        - In each department, HR can add, view, update, "delete" employee
      - **Project Exam Tracker**
        - User creates acount
        - User create, update, delete Courses
        - In the couress, user can create, update, delete projects/exam
        - Project/Exams will contain details (title, due date, desc, percentage weight, priority, reminders)
    - **_App Chosen_**
      - **Gift Wishlist App**
        - User creates an account
        - User creates a wishlist(s)
        - User can share wishlist (wishlists are accesible via link with a password)
        - Wishlists:
          - Name
          - Password
          - <Items>
          - Duedate?
        - Items : - Name - Description? - Size? - Price? - URL?
          Public can see , dont need to be logged in
          GET
          /wishlist/:id
          NEED TO BE LOGGED IN
          GETALL
          /wishlist
          POST
          /wishlist/create/
          EDIT
          /wishlist/edit/:id
          DELETE
          /wishlist/delete:id
- Dec 7 :
  - README project idea/scope
  - ~20 backlogs
    - Create Use Case Diagram :heavy_check_mark:
    - Create ERD :heavy_check_mark:
    - Create Mockup :heavy_check_mark:
    - Functional requirements
    - Non Functional requirements
    - Set Up Project :heavy_check_mark:
    - Set up F/E Repo :heavy_check_mark:
    - Add appsettings.json to gitignore
    - create appsettingsTEMPLATE.json
    - Update README
  - Mockup
  - ERD
  - Branches
  - Start coding
- Dec 8:

  - Initital Deploy

- Dec 9 :

  - DEV DAYS

- Dec 17:
  - FINAL COMMITS.

## Other notes ✏️

## Due Dates :bangbang:

- Dec 7 @ 11AM : Project Idea/Scope
- Dec 7 @ 5PM : A LOT OF STUFF lol
  - GH project Board
  - Proj Reqs
  - Issues !!!!!
  - ERD
  - Branches Created
- Dec 8 @ 5PM: Get site up and running + Deploy
- Dec 17 5PM : Final Commits. Project Due !!!!!
