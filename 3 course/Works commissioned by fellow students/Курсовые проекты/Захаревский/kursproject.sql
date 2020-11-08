-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 18 2018 г., 19:30
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
-- База данных: `kursproject`
--

-- --------------------------------------------------------

--
-- Структура таблицы `campony`
--

CREATE TABLE `campony` (
  `id_campony` int(11) NOT NULL,
  `id_gorod` int(11) NOT NULL,
  `nazvanie` varchar(99) NOT NULL,
  `adress` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `campony`
--

INSERT INTO `campony` (`id_campony`, `id_gorod`, `nazvanie`, `adress`) VALUES
(1, 1, 'Transit-plus', 'Санаторная 6'),
(2, 2, 'OZON.RU', 'Азбекская 20'),
(3, 2, 'Elitas', 'Ольшанка 3');

-- --------------------------------------------------------

--
-- Структура таблицы `gorod`
--

CREATE TABLE `gorod` (
  `id_gorod` int(11) NOT NULL,
  `id_obl` int(11) NOT NULL,
  `nazvanie` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `gorod`
--

INSERT INTO `gorod` (`id_gorod`, `id_obl`, `nazvanie`) VALUES
(1, 1, 'Брянск'),
(2, 2, 'Москва');

-- --------------------------------------------------------

--
-- Структура таблицы `obl`
--

CREATE TABLE `obl` (
  `id_obl` int(11) NOT NULL,
  `id_strana` int(11) NOT NULL,
  `nazvanie` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `obl`
--

INSERT INTO `obl` (`id_obl`, `id_strana`, `nazvanie`) VALUES
(1, 1, 'Московская область'),
(2, 2, 'Брянская область ');

-- --------------------------------------------------------

--
-- Структура таблицы `strana`
--

CREATE TABLE `strana` (
  `id_strana` int(11) NOT NULL,
  `Название` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `strana`
--

INSERT INTO `strana` (`id_strana`, `Название`) VALUES
(1, 'Россия'),
(2, 'Беларусь');

-- --------------------------------------------------------

--
-- Структура таблицы `tovar`
--

CREATE TABLE `tovar` (
  `id_tovar` int(11) NOT NULL,
  `id_typetovar` int(11) NOT NULL,
  `nazvanietovara` varchar(99) NOT NULL,
  `dataizg` date NOT NULL,
  `kolichest` varchar(99) NOT NULL,
  `cena` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `tovar`
--

INSERT INTO `tovar` (`id_tovar`, `id_typetovar`, `nazvanietovara`, `dataizg`, `kolichest`, `cena`) VALUES
(1, 1, 'Блочные кирпичи', '2015-05-16', '300 ', '500000'),
(2, 2, 'Металлические трубы', '2017-05-10', '50', '100000');

-- --------------------------------------------------------

--
-- Структура таблицы `transport`
--

CREATE TABLE `transport` (
  `id_transport` int(11) NOT NULL,
  `marka` varchar(99) NOT NULL,
  `model` varchar(99) NOT NULL,
  `gryzopod` varchar(99) NOT NULL,
  `gosnumber` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `transport`
--

INSERT INTO `transport` (`id_transport`, `marka`, `model`, `gryzopod`, `gosnumber`) VALUES
(1, 'SCANIA', 'XP350', '7000', 'х777ач777'),
(2, 'DAF', 'GT500', '10000', 'о007го777');

-- --------------------------------------------------------

--
-- Структура таблицы `transportirovka`
--

CREATE TABLE `transportirovka` (
  `id_transportirovka` int(11) NOT NULL,
  `id_campony` int(11) NOT NULL,
  `id_transport` int(11) NOT NULL,
  `id_tovar` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `transportirovka`
--

INSERT INTO `transportirovka` (`id_transportirovka`, `id_campony`, `id_transport`, `id_tovar`) VALUES
(2, 2, 2, 2),
(3, 1, 1, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `typetovar`
--

CREATE TABLE `typetovar` (
  `id_typetovar` int(11) NOT NULL,
  `naimenovanietipa` varchar(99) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `typetovar`
--

INSERT INTO `typetovar` (`id_typetovar`, `naimenovanietipa`) VALUES
(1, 'Блок'),
(2, 'Трубы');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `campony`
--
ALTER TABLE `campony`
  ADD PRIMARY KEY (`id_campony`);

--
-- Индексы таблицы `gorod`
--
ALTER TABLE `gorod`
  ADD PRIMARY KEY (`id_gorod`);

--
-- Индексы таблицы `obl`
--
ALTER TABLE `obl`
  ADD PRIMARY KEY (`id_obl`);

--
-- Индексы таблицы `strana`
--
ALTER TABLE `strana`
  ADD PRIMARY KEY (`id_strana`);

--
-- Индексы таблицы `tovar`
--
ALTER TABLE `tovar`
  ADD PRIMARY KEY (`id_tovar`);

--
-- Индексы таблицы `transport`
--
ALTER TABLE `transport`
  ADD PRIMARY KEY (`id_transport`);

--
-- Индексы таблицы `transportirovka`
--
ALTER TABLE `transportirovka`
  ADD PRIMARY KEY (`id_transportirovka`);

--
-- Индексы таблицы `typetovar`
--
ALTER TABLE `typetovar`
  ADD PRIMARY KEY (`id_typetovar`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `campony`
--
ALTER TABLE `campony`
  MODIFY `id_campony` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `gorod`
--
ALTER TABLE `gorod`
  MODIFY `id_gorod` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `obl`
--
ALTER TABLE `obl`
  MODIFY `id_obl` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `strana`
--
ALTER TABLE `strana`
  MODIFY `id_strana` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `tovar`
--
ALTER TABLE `tovar`
  MODIFY `id_tovar` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `transport`
--
ALTER TABLE `transport`
  MODIFY `id_transport` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `transportirovka`
--
ALTER TABLE `transportirovka`
  MODIFY `id_transportirovka` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `typetovar`
--
ALTER TABLE `typetovar`
  MODIFY `id_typetovar` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
