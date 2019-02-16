-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 06-02-2019 a las 01:08:03
-- Versión del servidor: 5.5.8
-- Versión de PHP: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `financialchatnet`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `messages`
--

CREATE TABLE IF NOT EXISTS `messages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `producer` varchar(255) NOT NULL,
  `consumer` varchar(255) NOT NULL,
  `message` text NOT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=22 ;

--
-- Volcar la base de datos para la tabla `messages`
--

INSERT INTO `messages` (`id`, `producer`, `consumer`, `message`, `date`) VALUES
(1, 'user2@gmail.com', 'cra1982@gmail.com', 'Hola como estas', '2019-02-04 20:26:53'),
(2, 'cra1982@gmail.com', 'user2@gmail.com', 'Hola que bien que escribes', '2019-02-04 20:27:11'),
(3, 'cra1982@gmail.com', 'cra1982@gmail.com', 'Que necesitas', '2019-02-04 20:27:54'),
(4, 'user2@gmail.com', 'cra1982@gmail.com', 'Hola', '2019-02-04 20:32:02'),
(5, 'cra1982@gmail.com', 'user2@gmail.com', 'Hola como vas', '2019-02-04 20:32:12'),
(6, 'user2@gmail.com', 'cra1982@gmail.com', 'Bien gracias', '2019-02-04 20:32:20'),
(7, 'cra1982@gmail.com', 'user2@gmail.com', 'puedes darme la valorizacion del aapl por favor', '2019-02-04 20:32:33'),
(8, 'user2@gmail.com', 'cra1982@gmail.com', 'esta en $171.27', '2019-02-04 20:32:53'),
(9, 'user2@gmail.com', 'cra1982@gmail.com', 'Hola', '2019-02-04 21:03:04'),
(10, 'cra1982@gmail.com', 'user2@gmail.com', 'Hola', '2019-02-04 21:03:23'),
(11, 'cra1982@gmail.com', 'user2@gmail.com', 'Hola', '2019-02-04 23:08:20'),
(12, 'user2@gmail.com', 'cra1982@gmail.com', 'Como vas', '2019-02-04 23:08:25'),
(13, 'user2@gmail.com', 'cra1982@gmail.com', 'Hola', '2019-02-05 12:12:37'),
(14, 'user2@gmail.com', 'cra1982@gmail.com', 'Hola', '2019-02-05 15:03:46'),
(15, 'cra1982@gmail.com', 'user2@gmail.com', 'Hola', '2019-02-05 15:03:50'),
(16, 'user2@gmail.com', 'user1@gmail.com', 'Hola', '2019-02-05 20:04:34'),
(17, 'user1@gmail.com', 'user2@gmail.com', 'Hola como vas', '2019-02-05 20:04:42'),
(18, 'user2@gmail.com', 'user1@gmail.com', 'bien gracias ', '2019-02-05 20:04:48'),
(19, 'user1@gmail.com', 'user2@gmail.com', 'Puedes darme el valor de aapl', '2019-02-05 20:04:57'),
(20, 'user2@gmail.com', 'user1@gmail.com', '$174.18', '2019-02-05 20:05:08'),
(21, 'user1@gmail.com', 'user2@gmail.com', 'gracias', '2019-02-05 20:05:14');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Volcar la base de datos para la tabla `users`
--

INSERT INTO `users` (`id`, `email`, `password`) VALUES
(1, 'cra1982@gmail.com', '123'),
(2, 'user2@gmail.com', '321'),
(3, 'user3@gmail.com', '123'),
(5, 'user1@gmail.com', '123');
