# Trivia System


# Tech Stack
- aspnetcore
- react js
- mysql (mirandaDb)

# Ideas
MVP "play a simple game with a logged in host, anonymous users, persistent questions, and lobby"
- G1 simple question answer game
    - 1.1 timer both modes
    - 1.2 scoring system
- M1.1 manual text answer evaluation
- M2 Chat
- M1.2.1 dumb auto evaluation
- A1 anonymous player users (log in as "sean")
- A2 luke needs to log in
- C3 SIMPLE input for hosts to track questions
- C3.2 SIMPLE voting system
- C4 Lobbies and room codes (jackbox tv style)
- Analytics, basic journaling

---
Notes
- games are ~15 people

---
**G**ames
1. simple question answer
    1. timer
        1. on demand when host feels like it
        1. fixed per question (able to change per question on demand)
    1. scoring system
        1. running leaderboard
        1. manual intervention (of host)
    1. chat that shows up after question
1. pub trivia format
    1. long poll bar trivia (weekly leaderboard)
1. jeopardy
1. family feud
1. the hints one.... where you can't say words and they have to guess a word
    1. pyramid!
    1. taboo?
1. battle royale trivia?
1. free for all trivia night
    1. as many players as can join
    1. times question/answer for N minutes
1. chain multiple games together
1. asynchronous trivia (long running games)
1. twitch chat votes for questions for streamer

---
**M**echanics
1. question evaluations
    1. Manually have host evaluate all answers
    1. Automatic evaluation of freeform text
        1. dumb brick word check (all lower, only alphanumeric)
        1. probably could use that phonome system... name? TODO
        1. % threshold for success/failure
    1. Dispute/appeal for wrong answers system (may only fit in some game formats)
    1. Multiple Choice
1. CHAT
    1. player chat
    1. chat messages have dynamic gamestate info (support pre/post question feature and more)

---
**A**ccounts
1. no login option "implicit account creation"/"soft accounts"
1. allow for real logins "social media aspect"
1. Oath, login with your friendster account

---
**C**ommunity?
1. game night calendar
1. LFG system
1. community question pooling
    1. able to track every interaction with questions (author, use, viewed/answered, voting, etc)
    1. voting scheme/rating on questions
    1. tags
        1. associated with questions when created
        1. players and anyone else can add tags at any time
        1. can be used for filtering and searching
    1. ranked by difficulty
        1. % answered correctly
        1. voted difficulty
    1. Shared or Private questions (only can be seen by creators)
    1. Question like/dislike/facebook-emoji users can attach to questions in games
    1. Users who write consistent garbage have their questions ... marked in some way
1. lobbies/room codes
1. teams?
1. report feature, all emails go to the court's #dumpster
1. voting on the features to be implemented
1. shop where you can spend your cumulative score
1. badges/achievement system
1. player stats (overwatch style)

---
**I**ntegrations
1. twitch live collaboration type thing
    1. chat votes on questions
    1. twitch embedded iframe video host stream
1. discord bot
1. discord voice and streaming (hard)
1. Sound Board
---
Analytics / Reporting
- journaling, so new features can have a populated data set when created later
---






npm run build <front end folder> <output folder>
dotnet publish release <aspnetcore folder> <publish folder>
nginx switch folders

https://reactjs.net/getting-started/aspnetcore.html
