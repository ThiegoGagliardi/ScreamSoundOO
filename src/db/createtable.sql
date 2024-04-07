CREATE DATABASE AvaliarBandas;
USE AvaliarBandas;

CREATE TABLE IF NOT EXISTS usuarios(
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    senha VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS bandas(
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    genero INT NOT NULL,
    fundacao DATETIME NOT NULL    
);

CREATE TABLE IF NOT EXISTS notas (    
    id_usuario INT NOT NULL,
    id_banda INT NOT NULL,
    nota INT NOT NULL,
    data TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id_usuario, id_banda),
    FOREIGN KEY (id_usuario) REFERENCES usuarios(id),
    FOREIGN KEY (id_banda) REFERENCES bandas(id)
);