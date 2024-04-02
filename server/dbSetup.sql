-- Active: 1711167878661@@127.0.0.1@3306@adaptable_shaman_540684_db
CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) COMMENT 'User Name',
    email varchar(255) COMMENT 'User Email',
    picture varchar(255) COMMENT 'User Picture'
  ) default charset utf8mb4 COMMENT '';

CREATE TABLE
  cults (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) NOT NULL,
    description VARCHAR(2000),
    coverImg VARCHAR(1000) NOT NULL,
    leaderId VARCHAR(255) NOT NULL,
    FOREIGN KEY (leaderId) REFERENCES accounts (id) ON DELETE CASCADE
  );

CREATE TABLE
  cultMembers (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    cultId int NOT NULL,
    accountId VARCHAR(255) NOT NULL,
    FOREIGN KEY (cultId) REFERENCES cults (id) ON DELETE CASCADE,
    FOREIGN KEY (accountId) REFERENCES accounts (id) ON DELETE CASCADE,
    UNIQUE (cultId, accountId)
  )
SELECT
  cultMember.*,
  account.*
FROM
  cultMembers cultMember
  JOIN accounts account ON cultMember.accountId = account.id
WHERE
  cultMember.id = 1;