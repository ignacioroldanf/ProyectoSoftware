use Diploma

INSERT INTO EstadoSuscripcion VALUES 
('Vigente'),
('Vencida');


INSERT INTO Clientes VALUES
(1,43234445, 'Nacho', 'Roldan', 'ignacio@gmail.com', '2024-05-10') 

select * from Planes

INSERT INTO Planes VALUES
('Plan Premium 1 Mes', 1, 1, 50000.0, 'Plan Premium con soporte de 1 mes de duración'), --es activo
('Plan Básico 1 Mes', 1, 0, 40000.0, 'Plan Básico con soporte de 1 mes de duración') --no es activo


INSERT INTO Suscripciones VALUES
(1,1,1,'2025-07-10', '2025-08-10')


-- Ejercicios
INSERT INTO Ejercicios VALUES
('Sentadillas', 'Ejercicio de piernas con barra y Rack'),
('Press de banca', 'Ejercicio de pecho con barra y banco en horizontal'),
('Remo con barra', 'Ejercicio de espalda con barra');


select * from Rutinas


ALTER TABLE DiasRutina
    ALTER COLUMN IdDiaRutina INT IDENTITY(1,1);
GO

