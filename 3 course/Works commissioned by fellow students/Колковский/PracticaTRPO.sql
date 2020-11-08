-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 19 2018 г., 22:59
-- Версия сервера: 5.6.38
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `PracticaTRPO`
--

-- --------------------------------------------------------

--
-- Структура таблицы `lico`
--

CREATE TABLE `lico` (
  `id` int(11) NOT NULL,
  `familiy` varchar(255) NOT NULL,
  `imy` varchar(255) NOT NULL,
  `otchestvo` varchar(255) NOT NULL,
  `passport` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `lico`
--

INSERT INTO `lico` (`id`, `familiy`, `imy`, `otchestvo`, `passport`) VALUES
(1, '1', '2', '3', '4'),
(2, 'a', 'b', 'c', 'd');

-- --------------------------------------------------------

--
-- Структура таблицы `pravonarushenie`
--

CREATE TABLE `pravonarushenie` (
  `id` int(11) NOT NULL,
  `nazvanie` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `pravonarushenie`
--

INSERT INTO `pravonarushenie` (`id`, `nazvanie`) VALUES
(1, 'Мелкое хулиганство'),
(2, 'Кража');

-- --------------------------------------------------------

--
-- Структура таблицы `predstavitel`
--

CREATE TABLE `predstavitel` (
  `id` int(11) NOT NULL,
  `familiy` varchar(255) NOT NULL,
  `imy` varchar(255) NOT NULL,
  `otchestvo` varchar(255) NOT NULL,
  `doljnost` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `predstavitel`
--

INSERT INTO `predstavitel` (`id`, `familiy`, `imy`, `otchestvo`, `doljnost`) VALUES
(1, '1', '2', '3', '4'),
(2, 'a', 'b', 'c', 'd');

-- --------------------------------------------------------

--
-- Структура таблицы `proisshestvie`
--

CREATE TABLE `proisshestvie` (
  `id` int(11) NOT NULL,
  `id_predstavitel` int(11) NOT NULL,
  `id_pravonarushenie` int(11) NOT NULL,
  `id_lico` int(11) NOT NULL,
  `id_svidetel` int(11) NOT NULL,
  `data` date NOT NULL,
  `nomer` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `proisshestvie`
--

INSERT INTO `proisshestvie` (`id`, `id_predstavitel`, `id_pravonarushenie`, `id_lico`, `id_svidetel`, `data`, `nomer`) VALUES
(1, 1, 1, 1, 1, '2018-06-19', 1),
(2, 2, 2, 2, 2, '2018-06-20', 2);

-- --------------------------------------------------------

--
-- Структура таблицы `svidetel`
--

CREATE TABLE `svidetel` (
  `id` int(11) NOT NULL,
  `familiy` varchar(255) NOT NULL,
  `imy` varchar(255) NOT NULL,
  `otchestvo` varchar(255) NOT NULL,
  `passport` varchar(255) NOT NULL,
  `mesto` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `svidetel`
--

INSERT INTO `svidetel` (`id`, `familiy`, `imy`, `otchestvo`, `passport`, `mesto`) VALUES
(1, '1', '2', '3', '4', '5'),
(2, 'a', 'b', 'c', 'd', 'e');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `lico`
--
ALTER TABLE `lico`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `pravonarushenie`
--
ALTER TABLE `pravonarushenie`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `predstavitel`
--
ALTER TABLE `predstavitel`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `proisshestvie`
--
ALTER TABLE `proisshestvie`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `svidetel`
--
ALTER TABLE `svidetel`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `lico`
--
ALTER TABLE `lico`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `pravonarushenie`
--
ALTER TABLE `pravonarushenie`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `predstavitel`
--
ALTER TABLE `predstavitel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `proisshestvie`
--
ALTER TABLE `proisshestvie`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `svidetel`
--
ALTER TABLE `svidetel`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
