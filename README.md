# MonopolyTestApp
Тестовое задание для компании «Монополия»

Это консольное приложение с генерацией данных прямо в приложении. Параметры генерации настраиваються в MonopolyTestApp/DataGenerator/BoxParameters.cs и MonopolyTestApp/DataGenerator/PalletParameters.cs . Генерируется заданное количество паллет и для каждой паллеты генерируется заданное количество коробок. При добавлении коробки к паллете происходит проверка, что коробка не должна превышать по размерам паллету (по ширине и глубине). Программа генерации MonopolyTestApp/UI/DataGeneratorProgram.cs данных сообщяет сколько коробок не подошло по размеру.  

Для формирования вывода результатов по заданию используются классы наследуемые от интерфейса IDataWorker, MonopolyTestApp/DataWorker/GroupLifeWeight.cs и MonopolyTestApp/DataWorker/PalletsLifeVolume.cs .
