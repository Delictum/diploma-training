-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Сен 21 2018 г., 22:03
-- Версия сервера: 8.0.12
-- Версия PHP: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `SampApp1`
--

-- --------------------------------------------------------

--
-- Структура таблицы `testsampapp`
--

CREATE TABLE `testsampapp` (
  `id_TestSampApp` int(11) NOT NULL,
  `info_TestSampApp` varchar(255) NOT NULL DEFAULT 'Все работает'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `testsampapp`
--

INSERT INTO `testsampapp` (`id_TestSampApp`, `info_TestSampApp`) VALUES
(1, 'а'),
(2, 'б'),
(3, 'в'),
(4, 'г'),
(5, 'д');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `testsampapp`
--
ALTER TABLE `testsampapp`
  ADD PRIMARY KEY (`id_TestSampApp`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `testsampapp`
--
ALTER TABLE `testsampapp`
  MODIFY `id_TestSampApp` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
