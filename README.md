# Twitter Clone final project

This project consists of two repositories, [*TwitterCloneAPI*](https://github.com/symir/TwitterCloneAPI/) and [*TwitterCloneClient*](https://github.com/symir/TwitterCloneClient/). 

Backend and API is written in C# using ASP and Entity Framework, while frontend is Javascript using React.

* A diagram of the database design [(*twitterCloneDB.png*)](https://github.com/symir/TwitterCloneAPI/blob/master/twitterCloneDB.png) can be found in the root folder of this project (*TwitterCloneAPI*).
* An SQL file with inserts to populate a new database with sample data [(*popTwitterClone.sql*)](https://github.com/symir/TwitterCloneAPI/blob/master/popTwitterClone.sql) can be found in the root folder of this project (*TwitterCloneAPI*).

I opted for a simple two-table design for this project, one for *Users* and one for *Tweets*. *Users* consists of a *username*, *alias*, and *avatar*. *Username* and *alias* are mandatory.

Each entry in *Tweets* will have some fields NULL by design - whether *ReplyId* or *RetweetId* are populated or not determines whether the tweet is considered a **reply** or a **retweet**. By using a single table for all three types indexing can be done simply without having to futz around with timestamps when displayed on the tweet timeline. *UserId* value is mandatory.

Tweets are served out of the *Repository* and asynchronously through the *TweetsController* via a Data Transfer Object. Depending on the tweet type (by checking for the presence of *retweetId*, *replyId*, or neither, in that order), the system will load only 
relevant values into the DTO. This means that if, for example, a tweet is somehow created that contains both *retweetId*, *replyId*, and *content*, the system will consider it a **retweet** and only transfer the *retweetId* and *userId* values, returning a JSON object with *content* and *replyId* as NULL.

The frontend is built in React, uses React-Bootstrap for styling purposes, Axios for async HTTP GET/PUT/POST calls, and React-Router to simulate subdirectories and allow direct linking to individual tweets. It implements the central timeline for *tweets*, collapsible navbar on breakpoints, and also has Search and Trends as non-interactive placeholders. Only Home in the nav links to anything (specifically to "/").

Tweet cards display *content*, *username* and *alias*, along with the chosen *avatar* (1-3 for female, male, and neutral). Counters for number of **likes**, **replies**, and **retweets**, are implemented as buttons that increment the like counter, add a reply (with modal reply post window), or add a retweet (with modal confirmation window), respectively. 

Additional info:
* CORS in the API is configured for *//localhost:3000*
* At minimum the system requires a single user to exist in the database, since *UserId* is mandatory for tweets. *UserId* 1 is hardcoded as the **active user** in the frontend.
