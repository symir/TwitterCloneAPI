INSERT INTO dbo.Users (UserName, Alias, Avatar)
VALUES 
('TestUser', 'Testy McTestface', 3),
('ASmithee', 'Alan Smithee', 2),
('ElChao','Elaine Chao',1),
('creepyDad','Woody Allen',2)

INSERT INTO dbo.Tweets (Content, UserId,ReplyId,RetweetId,LikeCounter)
VALUES
('Lorem ipsum dolor sit amet, consectetur adipiscing elit',1,NULL,NULL,4),
('sed quia non numquam eius modi tempora',2,1,NULL,30),
('nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?',1,NULL,NULL,22),
('consectetur, adipisci velit, sed quia non numquam',1,1,NULL,14245),
('totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo',1,NULL,NULL,19),
('Quis autem vel eum iure reprehenderit qui in ea voluptate',1,1,NULL,1),
('magni dolores eos qui ratione voluptatem sequi nesciunt',1,NULL,2,2),
('eaque ipsa quae ab illo inventore veritatis',1,NULL,NULL,1),
('My relationship with Soon-Yi is totally appropriate and normal',4,NULL,NULL,-1)