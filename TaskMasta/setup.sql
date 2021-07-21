CREATE TABLE List(
    id INT  NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'Primary Key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Last Update',
    name VARCHAR(255) NOT NULL COMMENT 'List Name',
    creatorId VARCHAR(255) NOT NULL COMMENT 'FK: User Account',
    FOREIGN KEY(creatorId) REFERENCES Accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';


CREATE TABLE Task(
id INT NOT NULL PRIMARY KEY AUTO_INCREMENT comment 'Primary Key',
createdAt DATETIME DEFAULT CURRENT_TIMESTAMP comment 'Time Created',
updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP comment  'Last Update',
name VARCHAR(255) NOT NULL COMMENT 'FK: User Account',
completed TINYINT default 0 comment 'Job Completed',
creatorId VARCHAR(255) NOT NULL COMMENT 'FK: User Account',
listId int NOT NULL COMMENT 'FK: List Id',
FOREIGN KEY(creatorId) REFERENCES Accounts(id) ON DELETE CASCADE,
FOREIGN KEY(listId) REFERENCES List(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';


 SELECT l.*,
                        a.*
                        FROM List l
                        JOIN  Accounts a ON l.creatorId = a.id
                        WHERE l.creatorId = @id;

                        SELECT * FROM Task WHERE listId = @id;


                         SELECT * FROM Task WHERE listId = @id AND creatorId = @userId;


                         SELECT * FROM Task WHERE ListId = 1 AND creatorId = '60f5e47037da3afb720feef4';