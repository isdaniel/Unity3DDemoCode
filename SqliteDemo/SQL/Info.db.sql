BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS `Person` (
	`RowID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`Name`	TEXT,
	`Age`	INTEGER
);
INSERT INTO `Person` (RowID,Name,Age) VALUES (1,'daniel',12),
 (6,'amy',12),
 (7,'amy',12);
COMMIT;
