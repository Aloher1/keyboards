-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1
-- Время создания: Янв 15 2023 г., 20:52
-- Версия сервера: 5.5.25
-- Версия PHP: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `keyboards`
--

-- --------------------------------------------------------

--
-- Структура таблицы `eng`
--

CREATE TABLE IF NOT EXISTS `eng` (
  `rus` varchar(100) NOT NULL,
  `eng` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `eng`
--

INSERT INTO `eng` (`rus`, `eng`) VALUES
('Поиск', 'Search'),
('Категория', 'Category'),
('Цена', 'Price'),
('Применить', 'Apply'),
('Название', 'Name'),
('Описание', 'Description'),
('Выбрать картинку', 'Choose picture'),
('Выберите категорию', 'Choose category'),
('Добавить', 'Add'),
('Введите почту', 'Enter your email'),
('Купить', 'Buy'),
('К оплате:', 'To pay:'),
('Добавлено', 'Added'),
('Добавить в корзину', 'Add to cart'),
('Вход', 'Login'),
('Регистрация', 'Registration'),
('Логин', 'Login'),
('Пароль', 'Password'),
('Войти', 'Login'),
('от', 'from'),
('до', 'to'),
('руб.', 'rub'),
('Корпуса', 'Cases'),
('Плейты', 'Plates'),
('Переключатели', 'Switches'),
('Платы', 'PCBs'),
('Кейкапы', 'Keycaps'),
('менее', 'less than'),
('больше', 'over');

-- --------------------------------------------------------

--
-- Структура таблицы `loginpassword`
--

CREATE TABLE IF NOT EXISTS `loginpassword` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `login` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Дамп данных таблицы `loginpassword`
--

INSERT INTO `loginpassword` (`id`, `login`, `password`) VALUES
(1, 'admin', 'admin'),
(2, '123', '123123'),
(3, '4321', '4321');

-- --------------------------------------------------------

--
-- Структура таблицы `objects`
--

CREATE TABLE IF NOT EXISTS `objects` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `category` varchar(20) NOT NULL,
  `price` int(100) NOT NULL,
  `description` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=36 ;

--
-- Дамп данных таблицы `objects`
--

INSERT INTO `objects` (`id`, `name`, `category`, `price`, `description`) VALUES
(1, '60% BAMBOO CASE', 'Корпуса', 4600, 'Это просто корпус для клавиатуры, а не клавиатура.\nМатериал - бамбук, совместим с клавиатурами с 60% раскладкой, такими как GH60, POKER, DZ60 и т. Д.'),
(2, 'TOFU84 case', 'Корпуса', 8000, 'Материал: алюминий/акрил\nСтруктура: Tray Mount\nВес: около 1185 грамм\nФормфактор: 75%\nСовместим с KBD75 REV 2.0 Solder PCB, KBD75RGB HOT-SWAP PCB (PER-KEY RGB)'),
(3, '60% WALNUT CASE', 'Корпуса', 5500, 'Это просто корпус для клавиатуры, а не клавиатура.\nСовместим с DZ60, GH60 и т.д'),
(4, 'A60 ALUMINIUM CASE 60%', 'Корпуса', 5800, 'Alumimum material\nCompatible with DZ60 Rev 3.0 soldered PCB, DZ60 RGB-ANSI/DZ60RGB V2 Hot-swap PCB'),
(5, 'POSEIDON PSD60', 'Корпуса', 5085, 'Dimension: around 32 x 11.5 x 2.1 (3.2 back height) cm\nBattery Room -  around 8.5 x 4 cm\nRound corner\nNet Weight: around 1.2 KG\n'),
(6, 'TOFU60 ACRYLIC FROSTED 60% CASE', 'Корпуса', 7051, 'Acrylic frosted\n60% layout\nCompatible with DZ60 rev3.0, DZ60RGB V2, DZ60RGB-ANSI, GH60, Poker2 etc\nTyping angle: 7 degree \nWeight: around 600g\\'),
(7, 'ALOPOW 60% RESIN', 'Корпуса', 4406, '60% Акриловый корпус\nСовместим только с DZ60rev3.0 PCB \nРазмеры: 306*119*29*22 мм\nГлубина батарейного отсека 3 мм\nВырез для USB 6 мм\n'),
(8, 'KBD67 LITE ABS', 'Корпуса', 2323, 'Содержит винты, резиновые ножки'),
(9, '60% BRASS ANSI PLATE', 'Плейты', 3192, 'Латунный плейт'),
(10, 'KBD75 PLATE', 'Плейты', 2190, 'Алюминий\nСовместим только с KBD75 v3/v3.1'),
(11, 'TOFU84 ALUMINUM PLATE', 'Плейты', 1597, 'Алюминий\nФормфактор 75%\nСовместимость с клавиатурой Tofu84.\nПлейт Tofu84 совместим с корпусом KBD75 v2, плейт KBD75 V2 несовместим с корпусом Tofu84.'),
(12, 'DZ60RGB V2 PLATE', 'Плейты', 4393, 'ПО: VIA\nРаскладка:63 клавиши\nПорт платы: Type-C\nHot-swap\n'),
(13, 'KBDPAD MARK II PLATE', 'Плейты', 1437, 'Совместим только с KBDPAD MarK II'),
(14, 'KBD67 MARK II RGB V3 PCB', 'Платы', 4393, 'Software Support: VIA\nPCB Port: Type-C\nRGB support: Per-Key RGB on top, no RGB underglow\nPCB Version: Hot-swap\nSwitch: 3-pin/5-pin Cherry MX-style\nCompatibility\n\nCompatible with KBD67MarK II, KBD67 lite, Blade65，D65，KBD67v3 aluminum cases\n'),
(15, 'TOFU96 SOLDERED PCB', 'Платы', 3913, 'Solderable version\n96% Layout'),
(16, 'KBD67 REV2 65% PCB', 'Платы', 3115, 'Software Support: VIA\nSize: 65% layout\nPCB Port: Type-C\nPCB Version: Solder\nRGB support: RGB underglow \n\nCompatible with the Tofu65 case, but it only has 4 screw holes to support this PCB.\nThe PCB is NOT compatible with KBD67 MarK II, KBD67 V3, KBD67 Lite cases.'),
(17, 'KBD75 REV 2.0 PCB', 'Платы', 3188, 'KBD75 PCB Rev1 does NOT support Numpad layout, the KBD75 Rev2 PCB supports\n\nSoftware Support: VIA\nPCB Port: Type-C\nPCB Version: Solder\nRGB support: RGB underglow\nFit with KBD75 v1/v2/v3.1, Tofu84, D84 solder version keyboard'),
(18, 'DZ60 60% PCB', 'Платы', 3028, 'DZ60 rev 3.0 solderable PCB, 1.6mm thickness\nDZ60 v2 flex cut solderablePCB, 1.2mm thickness (includes stabilizers shims)\nPCB Port: Type-C\nSoftware Support: VIA\nRGB support: RGB underglow\nQMK Flash Manual Link\n\nCompatible with Tofu60%, Blade 60%, 60% Plastic, 60% ALUMINUM LOW PROFILE, 60% Bamboo, 60% Wood, KBDfans 5° 60%, D60 HHKB/WKL/WK cases\nCompatible with DZ60 CNC ALUMINUM/BRASS 60% PLATE, 60% CNC''D ALUMINUM PLATE, 60% BRASS ANSI PLATE, 60% PC MATERIAL PLATE, CARBON FIBER 60% PLATE, D60 FR4/ PC PLATE/BRASS'),
(19, 'DZ60RGB V2 PCB', 'Платы', 4378, 'Software Support: VIA\nLayout: 63 Keys layout only\nPCB Port: Type-C\nRGB support: Per-Key RGB on top, no RGB underglow\nPCB Version: Hot-swap\nNote: This PCB supports arrow keys option'),
(20, 'DZ60RGB-ANSI V2 PCB', 'Платы', 4365, 'Software Support: VIA\nPCB Version: Hot-swap\nPCB Port: Type-C\nRGB support: Per-Key RGB on top, no RGB underglow\nLayout: 60% ANSI layout\nCompatible with Cherry MX-style 3pin/5pin switches'),
(21, 'DZ65 RGB V3 PCB', 'Платы', 4603, 'Wired version\nCompatible with Tofu65 case\nSoftware Support: VIA\nPCB Port: Type-C\nRGB support: Per-key RGB\nPCB Version: Hot-swap'),
(22, 'KBD75 RGB PCB', 'Платы', 4365, 'Software Support: VIA\nPCB Port: Type-C\nLayout: 75% fixed Layout (84 keys)\nRGB support: RGB underglow \nQMK, VIA support (Pre-flashed with VIA compatible firmware already)\n\nOnly compatible with KBD75 v3/ v3.1, D84 case\nNOT compatible with the Tofu84 case\nCase foam: KBD75 case foam (Hot-swap Version)\nPCB foam: KBD75 PCB foam '),
(23, 'KBDPAD MARK II PCB', 'Платы', 1984, 'Software Support: VIA\nPCB Port: Type-C\nPCB Version: Solder\nRGB support: RGB underglow \n\nOnly Compatible with KBDPAD MarK II case'),
(24, 'GATERON BLACK SWITCHES', 'Переключатели', 318, 'Производитель: Gateron\nТип: линейный\nСила нажатия: 60 грамм (тяжёлые)\nДлина хода: 4 мм (2 мм до срабатывания)\nАналог Cherry МХ Вlack от Gateron. Очень тяжёлое нажатие делает эти\nпереключатели лучшим выбором для тех, у копо тяжёлая рука, или у копо\nна более лёгких переключателях часто проскакивают фантомные нажатия '),
(25, 'GATERON BROWN SWITCHES', 'Переключатели', 318, 'Производитель: Gateron\nТип: тактильный\nСила нажатия: 45 грамм (лёгкие)\nДлина хода: 4 мм (2.65 мм до срабатывания)\nАналог Cherry MX Brown от Gateron. Подходят для многих задач и чаще всего нравятся тем, кто много времени проводит за набором текста.\n'),
(26, 'GATERON CLEAR SWITCHES', 'Переключатели', 318, 'Производитель: Gateron\nТип: линейный\nСила нажатия: 35 грамм \nДлина хода: 4 мм (2 мм до срабатывания)\nЛинейные переключатели от Gateron. Суперлёгкие и гладкие, подойдут для фанатов максимально воздушных ощущений от переключателей.э'),
(27, 'GATERON GREEN SWITCHES', 'Переключатели', 318, 'Производитель: Gateron\nТип: кликающий\nСила нажатия: 80 грамм (очень тяжёлые)\nДлина хода: 4 мм (2 мм до срабатывания)\nАналог Cherry МХ Green от Gateron. Очень тяжёлое нажатие и звук\nпечатной машинки делают эти переключатели весьма специфическим и\nизысканным блюдом в рационе любого клавиатурного маньяка\n'),
(28, 'GATERON RED SWITCHES', 'Переключатели', 318, 'Производитель: Gateron\nТип: линейный\nСила нажатия: 45 грамм (лёгкие)\nДлина хода: 4 мм (2 мм до срабатывания)\nАналог Cherry МХ Red от Gateron. Классика жанра, подойдут для\nбольшинства целей, ссобенно для игр.'),
(29, 'Kailh Box Brown Switches', 'Переключатели', 302, 'Производитель: Kailh\nТип: тактильный\nСила нажатия: 45 грамм (лёгкие)\nДлина хода: 3.6 мм (1.8 мм до срабатывания)\nАналог Cherry МХ Brown от kailh с чуточку укороченной длиной хода.\nКонтактные пластины закрыты защитной пластиковой коробкой, что\nобеспечивает защиту от пыли и влаги IP56.'),
(32, 'Kailh Box Red Switches', 'Переключатели', 300, 'Производитель: Kailh\nТип: линейный\nСила нажатия: 45 грамм (лёгкие)\nДлина хода: 3.6 мм (1.8 мм до срабатывания)\nАналог Cherry МХ Red от kailh с чуточку укороченной длиной хода.\nКонтактные пластины закрыты защитной пластиковой коробкой, что\nсбеспечивает защиту от пыли и влаги IP56.\n'),
(35, 'GAY', 'Плейты', 0, '');

-- --------------------------------------------------------

--
-- Структура таблицы `rus`
--

CREATE TABLE IF NOT EXISTS `rus` (
  `key` varchar(100) NOT NULL,
  `value` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `rus`
--

INSERT INTO `rus` (`key`, `value`) VALUES
('Поиск', 'Поиск'),
('Категория', 'Категория'),
('Цена', 'Цена'),
('Применить', 'Применить'),
('Название', 'Название'),
('Описание', 'Описание'),
('Выбрать картинку', 'Выбрать картинку'),
('Выберите категорию', 'Выберите категорию'),
('Добавить', 'Добавить'),
('Введите почту', 'Введите почту'),
('Купить', 'Купить'),
('К оплате:', 'К оплате:'),
('Добавлено', 'Добавлено'),
('Добавить в корзину', 'Добавить в корзину'),
('Регистрация', 'Регистрация'),
('Вход', 'Вход'),
('Логин', 'Логин'),
('Пароль', 'Пароль'),
('Войти', 'Войти'),
('от', 'от'),
('до', 'до'),
('руб.', 'руб.'),
('Корпуса', 'Корпуса'),
('Плейты', 'Плейты'),
('Переключатели', 'Переключатели'),
('Платы', 'Платы'),
('Кейкапы', 'Кейкапы'),
('менее', 'менее'),
('больше', 'больше');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
