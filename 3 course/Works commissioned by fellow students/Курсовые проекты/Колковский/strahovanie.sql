-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 20 2018 г., 20:03
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
-- База данных: `strahovanie`
--

-- --------------------------------------------------------

--
-- Структура таблицы `agent`
--

CREATE TABLE `agent` (
  `id` int(11) NOT NULL,
  `familiy` varchar(255) NOT NULL,
  `firma` varchar(255) NOT NULL,
  `stazh` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `agent`
--

INSERT INTO `agent` (`id`, `familiy`, `firma`, `stazh`) VALUES
(1, 'Пупкин', 'Страховой полис', '14'),
(2, 'Золотце', 'Белстрах', '5');

-- --------------------------------------------------------

--
-- Структура таблицы `client`
--

CREATE TABLE `client` (
  `id` int(11) NOT NULL,
  `familiy` varchar(255) NOT NULL,
  `passport` varchar(255) NOT NULL,
  `adress` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `client`
--

INSERT INTO `client` (`id`, `familiy`, `passport`, `adress`) VALUES
(1, 'Скорябкин', 'КН2421343', 'Поповича 16'),
(2, 'Захаревский', 'КН3521541', 'Клецкова 10');

-- --------------------------------------------------------

--
-- Структура таблицы `dogovor`
--

CREATE TABLE `dogovor` (
  `id` int(11) NOT NULL,
  `id_client` int(11) NOT NULL,
  `id_agent` int(11) NOT NULL,
  `id_strahovka` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `dogovor`
--

INSERT INTO `dogovor` (`id`, `id_client`, `id_agent`, `id_strahovka`) VALUES
(1, 2, 1, 2),
(2, 1, 2, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `strahovka`
--

CREATE TABLE `strahovka` (
  `id` int(11) NOT NULL,
  `nazvanie` varchar(255) NOT NULL,
  `stoimost` varchar(255) NOT NULL,
  `opisanie` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `strahovka`
--

INSERT INTO `strahovka` (`id`, `nazvanie`, `stoimost`, `opisanie`) VALUES
(1, 'Страхование квартиры++', '1450', 'Страхование квартиры по всем критериям люкс класса'),
(2, 'Страхование авто', '300', 'Страхование авто в аварийных ситуациях');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `agent`
--
ALTER TABLE `agent`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `dogovor`
--
ALTER TABLE `dogovor`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `strahovka`
--
ALTER TABLE `strahovka`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `agent`
--
ALTER TABLE `agent`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `client`
--
ALTER TABLE `client`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `dogovor`
--
ALTER TABLE `dogovor`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `strahovka`
--
ALTER TABLE `strahovka`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
