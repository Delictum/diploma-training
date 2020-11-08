-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Сен 20 2017 г., 20:58
-- Версия сервера: 5.5.53
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `LR_8`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Air`
--

CREATE TABLE `Air` (
  `ID` int(11) NOT NULL,
  `Number` int(11) NOT NULL,
  `Type` varchar(255) NOT NULL,
  `Naznachenie` varchar(255) NOT NULL,
  `Time` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Air`
--

INSERT INTO `Air` (`ID`, `Number`, `Type`, `Naznachenie`, `Time`) VALUES
(1, 2512, 'General', 'Минск', '2017-09-20 03:36:08'),
(2, 1123, 'Holy', 'Гродно', '2017-09-24 06:07:25'),
(3, 123, 'Holy', 'Москва', '2017-09-21 13:07:27'),
(4, 75, 'Sinops', 'Берлин', '2017-09-17 05:14:32'),
(5, 53, 'General', 'Лондон', '2017-09-21 17:54:22');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Air`
--
ALTER TABLE `Air`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Air`
--
ALTER TABLE `Air`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
