# NET Project Team 6 💠

- Fatma
- Stefan
- Nicholas
- Vlad
- Russ

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

## Timeline 🕗

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
        - Items :
          - Name
          - Description?
          - Size?
          - Price?
          - URL?
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
