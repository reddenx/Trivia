# Phase 0 Design (MVP)
## User Stories

1. System
    1. [x] As a user I would like to be able to participate via a mobile device or pc.

2. Account
    1. [x] As a player I would like to play without creating an account.
    2. [x] As a player I would like to give a username to use when playing.
    3. [x] As a user I would like the site to remember me and auto log me in.
    4. [x] As a user when I log in I would like to be able to see current stats about my quizzes.
    5. [x] As a user I would like the site to allow me to login
    6. [x] As a user I would like to see stats about how well I answer questions related to a tag.
    7. [x] As a user without an account, I would like to switch to another device using some sort of code thing.
    8. [x] As a user, I would like a "trust score" to prevent spammy accounts that can abuse reporting tools
    9. [x] As a instance user, I would like to convert my account over to a permamnent account

3. Game
    1. Create/Host Setup:
        1. [ ] As a host I would like to be able to load a previous quiz once logged in.
        2. [ ] As a host I would like to save a set up quiz to my account.
        3. [ ] As a host setting up a game I would like to be able to filter questions from the pool by tags.
        4. [ ] As a host setting up a game I would like to be able to pull questions from a pool.
        5. [ ] As a host when creating a quiz would like to be able to set the question, the answer, if it has a time limit, what that time limit is and the total point value.
        6. [ ] As a host I would like to be able to create a new quiz.

    2. Initiating Game
        1. [ ] As a player I would like to be able to join a quiz via a room code.
        2. [ ] As a player I would like to be able to join a current quiz via link.

    3. Chat
        1. [ ] As a user I would like to be able to chat with other players post game.
        2. [ ] As a user I would like to be able to chat with other players participating in the quiz.
        3. [ ] As a host I would like to enable/disable chat for the entire game.

    4. Gameplay
        1. [ ] As a host I would like to be able to manually move to the next question.
        2. [ ] As a host I would like to be able to hide or display the current scores for the players.
        3. [ ] As a host I would like to be able to see a current score for all the players.
        4. [ ] As a host I would like to be able to give partial credit to an answer (points?).
        5. [ ] As a host I would like to manually review questions that aren't determined 100% correct by the application.
        6. [ ] As a player I would like to be able to answer a quiz question.
        7. [ ] As a user I would like a Presentation View (what the users would see during broadcast)

4. Trivia Question Management
    1. Creation
        1. [x] As a host I would like to be able to create a question with a user supplied answer.
        2. [x] As a host I would like to be able to create a multiple choice question.
    2. Organization
        1. [x] As a user I would like to be able to report questions.
    3. Management
        1. [x] As a user I would like to be able to rate questions.
        2. [x] As a host I would like to be able to flag an answer for a question as incorrect/invalid.
        3. [x] As a host I would like answers I decide are correct to be added to possible correct answers for the question.
        4. [x] As a user I would like to be able to tag questions for categorization later. (maybe only hosts have this ability?)

## Requirements
1. Account
    1. Instance Accounts
        1. Set username (US 2.2)
        2. Auto login/relog on refresh (US 2.3)
        3. (stretch) Track all stats on questions/answers in past games for user (2.4)
        4. (stretch) Some sort of ID to switch devices and re-authenticate (2.7)
        5. (stretch) Ability to "convert" instance account over to permanent account (2.9)
    2. Permanent Accounts
        1. Auto login/remember me (2.3)
        2. Track all stats on questions/answers in past games for user (2.4)
        3. Login with Email & Password (2.5)
        4. (stretch) Trust score with users based on reporting behavior (2.9)
        5. (stretchiest of stretches) Accounts can have avatars
    3. Login portal will be available by web (US 1.1)
    4. Users Can report Users

2. Trivia Questions
    1. A Question has a Prompt and a Response
        1. Prompt can be Plain Text
        2. (stretch) Prompt can be Images
        3. (stretch) Prompt can be video
        4. Prompt can be Markdown
            1. (stretch) Rich text editor
        5. (stretch) Response can be multiple choice
            1. N number of choices may be correct
        6. Responses can be plain text
        7. (stretch) Responses can be blank for judgement/vote to win
        8. Responses have multiple content types (multiple choice, plain text, etc.)
        9. A question can have multiple responses of the same type
    2. (stretch) Questions can have an optional noted difficulty on a scale (0 to 100)
    3. (stretch) A Question has Host Notes
    4. CRUD operations (4.1.1, 4.1.2)
    5. (stretch) Questions can be reported by users (4.2.1, 4.3.1)
        1. Reporting can be "invalid" "offensive" etc. think of more
    6. (stretch) Questions track users who have interacted with a question
        1. (stretch) Questions track previous answers from players
        2. (stretch) Questions track users that have viewed questions before (through gameplay or host mechanics)
    7. (stretch) A Question can be rated by users (keep to a generic float format 0 to 1)
    8. A question can have tags? associated with it for categorization

3. Gameplay
    1. Luke's Game
        1. 
    



- Game
    - TODO needs a full narrative before requirements can be made

- Generic

## Components
### Front-end
### Back-end
### Data

## Infrastructure

## Deployment

## Testing (maybe)

## Terminology
- User: anyone using the system
- Player: non host user in a game
- Host: user running a game
