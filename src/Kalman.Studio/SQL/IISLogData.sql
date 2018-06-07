create table IISLogData (
   LogID                int                  identity,
   LogTime              datetime             null,
   Method               varchar(8)           null,
   ClientIP             varchar(20)          null,
   ClientIPLocation     varchar(100)         null,
   Status               varchar(10)          null,
   SubStatus            varchar(10)          null,
   Win32Status          varchar(10)          null,
   ReceiveBytes         varchar(10)                  null,
   SendBytes            varchar(10)                  null,
   UriStem              varchar(1024)        null,
   Referer              varchar(1024)        null,
   UriStemAlias         varchar(100)         null,
   RefererAlias         varchar(100)         null,
   UserAgentAlias       varchar(100)         null,
   UserAgent            varchar(1024)        null,
   constraint PK_IISLOGDATA primary key (LogID)
)
go