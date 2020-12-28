CREATE DATABASE "InBarDatabase"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;


CREATE TABLE public."user"
(
    email text NOT NULL,
    "userId" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 256 ),
    password text NOT NULL,
    PRIMARY KEY ("userId")
);

ALTER TABLE public."user"
    OWNER to postgres;