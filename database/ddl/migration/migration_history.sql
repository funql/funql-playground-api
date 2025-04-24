CREATE TABLE migration.migration_history
(
    id varchar(150) NOT NULL
        CONSTRAINT migration_history_pkey
            PRIMARY KEY,
    create_time timestamp WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP NOT NULL
);

ALTER TABLE migration.migration_history
    OWNER TO postgres;