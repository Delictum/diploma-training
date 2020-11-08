-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 08 2018 г., 12:34
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
-- База данных: `Firma`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Detali`
--

CREATE TABLE `Detali` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `artikul` int(11) NOT NULL,
  `cena` int(11) NOT NULL,
  `primechanie` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Detali`
--

INSERT INTO `Detali` (`id`, `name`, `artikul`, `cena`, `primechanie`) VALUES
(1, 'Шестеренка', 2431, 2, 'Размер 2*2'),
(2, 'Шуруп', 6532, 1, 'Разрез с оконтовкой'),
(3, '2', 2, 2, '2');

-- --------------------------------------------------------

--
-- Структура таблицы `Postavki`
--

CREATE TABLE `Postavki` (
  `id` int(11) NOT NULL,
  `id_postavshik` int(11) NOT NULL,
  `id_detali` int(11) NOT NULL,
  `kolichestvo` int(11) NOT NULL,
  `data` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Postavki`
--

INSERT INTO `Postavki` (`id`, `id_postavshik`, `id_detali`, `kolichestvo`, `data`) VALUES
(1, 2, 1, 80, '2018-05-02'),
(2, 1, 2, 400, '2018-05-09'),
(4, 1, 1, 1, '1111-11-11'),
(5, 1, 1, 40, '2010-12-21');

-- --------------------------------------------------------

--
-- Структура таблицы `Postavshik`
--

CREATE TABLE `Postavshik` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `adress` varchar(255) NOT NULL,
  `telephone` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Postavshik`
--

INSERT INTO `Postavshik` (`id`, `name`, `adress`, `telephone`) VALUES
(1, 'Трусов', 'Гродно, Поповича 15-6', 3456789),
(2, 'Герук', 'Гродно, Весенняя 22-30', 1234567),
(3, '2', '2', 2);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Detali`
--
ALTER TABLE `Detali`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Postavki`
--
ALTER TABLE `Postavki`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Postavshik`
--
ALTER TABLE `Postavshik`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Detali`
--
ALTER TABLE `Detali`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `Postavki`
--
ALTER TABLE `Postavki`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `Postavshik`
--
ALTER TABLE `Postavshik`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
