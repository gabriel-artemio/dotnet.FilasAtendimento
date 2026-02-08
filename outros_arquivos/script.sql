CREATE TABLE unidade (
    cd_unidade INTEGER AUTOINCREMENT PRIMARY KEY,
    nm_unidade TEXT NOT NULL,
    ativo TEXT DEFAULT '1'
);

CREATE TABLE servico (
    cd_servico INTEGER AUTOINCREMENT PRIMARY KEY,
    nm_servico TEXT NOT NULL,
    ativo TEXT DEFAULT '1'
);

CREATE TABLE unidade_servico (
    cd_unidade_servico INTEGER AUTOINCREMENT PRIMARY KEY,
    cd_unidade INTEGER,
	cd_servico INTEGER,
    ativo TEXT DEFAULT '1'
);

CREATE TABLE prioridade (
    cd_prioridade INTEGER AUTOINCREMENT PRIMARY KEY,
    nm_prioridade TEXT NOT NULL
);

CREATE TABLE senha (
    cd_senha INTEGER AUTOINCREMENT PRIMARY KEY,
    nm_prioridade TEXT NOT NULL,
	cd_unidade INTEGER,
	cd_servico INTEGER,
	sigla TEXT NOT NULL,
	dt_senha TEXT DEFAULT CURRENT_TIMESTAMP
);