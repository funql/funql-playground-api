-- Make sure migration_history table exists
CREATE SCHEMA IF NOT EXISTS migration;
CREATE TABLE IF NOT EXISTS migration.migration_history
(
    id varchar(150) NOT NULL
        CONSTRAINT migration_history_pkey
            PRIMARY KEY,
    create_time timestamp WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP NOT NULL
);

START TRANSACTION;

DO $$
BEGIN
-- Check if migration not yet applied
IF NOT EXISTS(SELECT 1 FROM migration.migration_history WHERE id = '20250424111500_initial_create') THEN

-- ============================ Migration start ============================

-- Make sure uuid-ossp is supported
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE SCHEMA application;

CREATE TABLE application.category
(
    id integer NOT NULL
        CONSTRAINT category_pkey
            PRIMARY KEY,
    name varchar(100) NOT NULL
);

ALTER TABLE application.category
    OWNER TO postgres;

CREATE UNIQUE INDEX category_name_key
    ON application.category (name);

CREATE TABLE application.packaging_type
(
    id integer NOT NULL
        CONSTRAINT packaging_type_pkey
            PRIMARY KEY,
    name varchar(100) NOT NULL
);

ALTER TABLE application.packaging_type
    OWNER TO postgres;

CREATE UNIQUE INDEX packaging_type_name_key
    ON application.packaging_type (name);

CREATE TABLE application.region
(
    id integer NOT NULL
        CONSTRAINT region_pkey
            PRIMARY KEY,
    name varchar(100) NOT NULL
);

ALTER TABLE application.region
    OWNER TO postgres;

CREATE UNIQUE INDEX region_name_key
    ON application.region (name);

CREATE TABLE application.theme
(
    id integer NOT NULL
        CONSTRAINT theme_pkey
            PRIMARY KEY,
    name varchar(100) NOT NULL
);

ALTER TABLE application.theme
    OWNER TO postgres;

CREATE UNIQUE INDEX theme_name_key
    ON application.theme (name);

CREATE TABLE application.designer
(
    id uuid DEFAULT uuid_generate_v4() NOT NULL
        CONSTRAINT designer_pkey
            PRIMARY KEY,
    name varchar(255) NOT NULL
);

ALTER TABLE application.designer
    OWNER TO postgres;

CREATE TABLE application.minifigure
(
    id uuid DEFAULT uuid_generate_v4() NOT NULL
        CONSTRAINT minifigure_pkey
            PRIMARY KEY,
    name varchar(255) NOT NULL
);

ALTER TABLE application.minifigure
    OWNER TO postgres;

CREATE TABLE application.set
(
    id uuid DEFAULT uuid_generate_v4() NOT NULL
        CONSTRAINT set_pkey
            PRIMARY KEY,
    name varchar(255) NOT NULL,
    set_number integer NOT NULL,
    pieces integer NOT NULL,
    price numeric(19, 4) NOT NULL,
    designer_id uuid NOT NULL
        CONSTRAINT set_designer_id_fkey
            REFERENCES application.designer (id),
    launch_time timestamp WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP NOT NULL,
    packaging_type_id integer NOT NULL
        CONSTRAINT set_packaging_type_id_fkey
            REFERENCES application.packaging_type (id),
    theme_id integer NOT NULL
        CONSTRAINT set_theme_id_fkey
            REFERENCES application.theme (id)
);

ALTER TABLE application.set
    OWNER TO postgres;

CREATE UNIQUE INDEX set_set_number_key
    ON application.set (set_number);

CREATE TABLE application.set_category
(
    id uuid DEFAULT uuid_generate_v4() NOT NULL
        CONSTRAINT set_category_pkey
            PRIMARY KEY,
    set_id uuid NOT NULL
        CONSTRAINT set_category_set_id_fkey
            REFERENCES application.set (id)
            ON DELETE CASCADE,
    category_id integer NOT NULL
        CONSTRAINT set_category_category_id_fkey
            REFERENCES application.category (id)
            ON DELETE CASCADE
);

ALTER TABLE application.set_category
    OWNER TO postgres;

-- Unique category per set: only 1 entry per category allowed
CREATE UNIQUE INDEX set_category_set_id_category_id_key
    ON application.set_category (set_id, category_id);

CREATE TABLE application.set_item_number
(
    id uuid DEFAULT uuid_generate_v4() NOT NULL
        CONSTRAINT set_item_number_pkey
            PRIMARY KEY,
    set_id uuid NOT NULL
        CONSTRAINT set_item_number_set_id_fkey
            REFERENCES application.set (id)
            ON DELETE CASCADE,
    region_id integer NOT NULL
        CONSTRAINT set_item_number_region_id_fkey
            REFERENCES application.region (id)
            ON DELETE CASCADE,
    item_number integer NOT NULL
);

ALTER TABLE application.set_item_number
    OWNER TO postgres;

-- Unique region per set: only 1 entry per region allowed
CREATE UNIQUE INDEX set_item_number_set_id_region_id_key
    ON application.set_item_number (set_id, region_id);

CREATE TABLE application.set_minifigure
(
    id uuid DEFAULT uuid_generate_v4() NOT NULL
        CONSTRAINT set_minifigure_pkey
            PRIMARY KEY,
    set_id uuid NOT NULL
        CONSTRAINT set_minifigure_set_id_fkey
            REFERENCES application.set (id)
            ON DELETE CASCADE,
    minifigure_id uuid NOT NULL
        CONSTRAINT set_minifigure_minifigure_id_fkey
            REFERENCES application.minifigure (id)
            ON DELETE CASCADE,
    quantity integer NOT NULL
);

ALTER TABLE application.set_minifigure
    OWNER TO postgres;

-- Unique minifigure per set: only 1 entry per minifigure allowed
CREATE UNIQUE INDEX set_minifigure_set_id_minifigure_id_key
    ON application.set_minifigure (set_id, minifigure_id);

-- Data

INSERT INTO application.category (id, name)
VALUES  ('1', 'MOVIES'),
        ('2', 'VEHICLES'),
        ('3', 'ULTIMATE_COLLECTOR_SERIES');

INSERT INTO application.packaging_type (id, name)
VALUES  ('1', 'BOX'),
        ('2', 'POLYBAG');

INSERT INTO application.region (id, name)
VALUES  ('1', 'EUROPE'),
        ('2', 'NORTH_AMERICA');

INSERT INTO application.theme (id, name)
VALUES  ('1', 'BATMAN'),
        ('2', 'CITY'),
        ('3', 'CLASSIC'),
        ('4', 'HARRY_POTTER'),
        ('5', 'ICONS'),
        ('6', 'IDEAS'),
        ('7', 'LORD_OF_THE_RINGS'),
        ('8', 'MARVEL'),
        ('9', 'STAR_WARS'),
        ('10', 'TECHNIC');

-- ============================ Migration end ============================

-- Migration applied, so update history
INSERT INTO migration.migration_history (id)
VALUES ('20250424111500_initial_create');

END IF;
END $$;

COMMIT;

