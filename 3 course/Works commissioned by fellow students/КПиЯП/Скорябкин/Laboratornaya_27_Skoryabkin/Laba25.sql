-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 05 2018 г., 17:33
-- Версия сервера: 5.5.53
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `Laba25`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Raboti`
--

CREATE TABLE `Raboti` (
  `id` int(11) NOT NULL,
  `id1` int(11) NOT NULL,
  `Datanachala` date NOT NULL,
  `Dataokonchaniya` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Raboti`
--

INSERT INTO `Raboti` (`id`, `id1`, `Datanachala`, `Dataokonchaniya`) VALUES
(1, 2, '2003-12-20', '2004-12-20'),
(2, 2, '2020-09-20', '2020-10-20'),
(11, 1, '2012-12-12', '2011-12-12');

-- --------------------------------------------------------

--
-- Структура таблицы `Sotrydniki`
--

CREATE TABLE `Sotrydniki` (
  `id` int(10) UNSIGNED NOT NULL,
  `Familiya` text NOT NULL,
  `Name` text NOT NULL,
  `Otchestvo` text NOT NULL,
  `Oclad` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Sotrydniki`
--

INSERT INTO `Sotrydniki` (`id`, `Familiya`, `Name`, `Otchestvo`, `Oclad`) VALUES
(1, 'Скорябкин', 'Артём', 'Валерьевич', 500000),
(2, 'Кучинский', 'Владислав', 'Андреевич', 200000),
(3, 'Чверток', 'Артем', 'Александрович', 680000);

-- --------------------------------------------------------

--
-- Структура таблицы `VidiRabot`
--

CREATE TABLE `VidiRabot` (
  `id` int(11) NOT NULL,
  `Opisanie` text NOT NULL,
  `Oplatazaden` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `VidiRabot`
--

INSERT INTO `VidiRabot` (`id`, `Opisanie`, `Oplatazaden`) VALUES
(1, 'Обработка графической информации', 5000),
(2, 'Уборка помещений', 300),
(3, 'Уборка помещений', 1000);

-- --------------------------------------------------------

--
-- Структура таблицы `VipolnRaboti`
--

CREATE TABLE `VipolnRaboti` (
  `id` int(11) NOT NULL,
  `id_sotryd` int(11) NOT NULL,
  `id_raboti` int(11) NOT NULL,
  `dlitelnost` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `VipolnRaboti`
--

INSERT INTO `VipolnRaboti` (`id`, `id_sotryd`, `id_raboti`, `dlitelnost`) VALUES
(1, 1, 1, 3),
(2, 0, 2010, 6),
(3, 0, 2012, 10),
(4, 0, 2012, 12),
(5, 1, 1, 1);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Raboti`
--
ALTER TABLE `Raboti`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Sotrydniki`
--
ALTER TABLE `Sotrydniki`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `VidiRabot`
--
ALTER TABLE `VidiRabot`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `VipolnRaboti`
--
ALTER TABLE `VipolnRaboti`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Raboti`
--
ALTER TABLE `Raboti`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT для таблицы `Sotrydniki`
--
ALTER TABLE `Sotrydniki`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT для таблицы `VidiRabot`
--
ALTER TABLE `VidiRabot`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT для таблицы `VipolnRaboti`
--
ALTER TABLE `VipolnRaboti`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
