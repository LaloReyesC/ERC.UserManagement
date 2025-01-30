CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "UserAccounts" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_UserAccounts" PRIMARY KEY AUTOINCREMENT,
    "UserName" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "PasswordHash" TEXT NOT NULL,
    "RegistrationDate" TEXT NOT NULL DEFAULT (GETDATE())
);

CREATE TABLE "LoginHistories" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_LoginHistories" PRIMARY KEY AUTOINCREMENT,
    "UserAccountId" INTEGER NOT NULL,
    "LoginDate" TEXT NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT "FK_LoginHistories_UserAccounts_UserAccountId" FOREIGN KEY ("UserAccountId") REFERENCES "UserAccounts" ("Id")
);

CREATE INDEX "IX_LoginHistories_UserAccountId" ON "LoginHistories" ("UserAccountId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250130030731_InitialMigration', '8.0.12');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "UserAccounts" ADD "FailedAttemps" INTEGER NOT NULL DEFAULT 0;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250130043457_FailedAttempsAdded', '8.0.12');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "UserAccounts" ADD "LockoutEnd" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250130090232_LockoutEndAdded', '8.0.12');

COMMIT;

