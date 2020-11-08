-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Мар 04 2018 г., 01:21
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
-- База данных: `Practic`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Burden`
--

CREATE TABLE `Burden` (
  `id_load` int(11) NOT NULL,
  `code` int(11) NOT NULL,
  `number` int(11) NOT NULL,
  `hours` int(11) NOT NULL,
  `subject` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  `payment` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Burden`
--

INSERT INTO `Burden` (`id_load`, `code`, `number`, `hours`, `subject`, `type`, `payment`) VALUES
(3, 1, 1, 1, '1', '1', 1),
(4, 4, 7, 80, 'Акушерство', 'Практические', 180),
(5, 19, 51, 120, 'Приборостроение', 'Лекционный', 300),
(6, 51, 4, 40, 'Самооборона', 'Практические', 50);

-- --------------------------------------------------------

--
-- Структура таблицы `Groups`
--

CREATE TABLE `Groups` (
  `id_groups` int(11) NOT NULL,
  `number` int(11) NOT NULL,
  `cpecialization` varchar(255) NOT NULL,
  `secession` int(11) NOT NULL,
  `count` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Groups`
--

INSERT INTO `Groups` (`id_groups`, `number`, `cpecialization`, `secession`, `count`) VALUES
(2, 19, 'Автоматизация', 8, 11),
(3, 4, 'Сестринское дело', 2, 9);

-- --------------------------------------------------------

--
-- Структура таблицы `Teachers`
--

CREATE TABLE `Teachers` (
  `id_teachers` int(11) NOT NULL,
  `code` int(11) NOT NULL,
  `surname` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `patronymic` varchar(255) NOT NULL,
  `telphone` int(11) NOT NULL,
  `experience` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Teachers`
--

INSERT INTO `Teachers` (`id_teachers`, `code`, `surname`, `name`, `patronymic`, `telphone`, `experience`) VALUES
(1, 51, 'Зданевский', 'Алексей', 'Андреевич', 336868686, 4),
(2, 7, 'Михальчик', 'Василиса', 'Игнатьевна', 333636363, 11);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Burden`
--
ALTER TABLE `Burden`
  ADD PRIMARY KEY (`id_load`);

--
-- Индексы таблицы `Groups`
--
ALTER TABLE `Groups`
  ADD PRIMARY KEY (`id_groups`);

--
-- Индексы таблицы `Teachers`
--
ALTER TABLE `Teachers`
  ADD PRIMARY KEY (`id_teachers`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Burden`
--
ALTER TABLE `Burden`
  MODIFY `id_load` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `Groups`
--
ALTER TABLE `Groups`
  MODIFY `id_groups` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `Teachers`
--
ALTER TABLE `Teachers`
  MODIFY `id_teachers` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
