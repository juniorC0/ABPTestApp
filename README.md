REST API для АБ-тестів
Цей проект містить REST API, що складається з 2 ендпоітнів, які дозволяють проводити АБ-тести.

Встановлення та запуск
Клонуйте цей репозиторій
Встановіть залежності, виконавши команду npm install
Запустіть сервер, виконавши команду npm start
Ендпоінти
1. /experiment/button-color
Цей ендпоінт дозволяє проводити АБ-тестування коліру кнопки "Купити".

Запит
Type: GET

Parameters:

device-token: унікальний ідентифікатор пристрою, що зберігається між сесіями.
Відповідь
У відповідь сервер повертає JSON об'єкт з ключем "button_color" та значенням однієї з наступних опцій:

#FF0000 (33.3%)
#00FF00 (33.3%)
#0000FF (33.3%)
2. /experiment/price
Цей ендпоінт дозволяє проводити АБ-тестування зміни вартості покупки в додатку.

Запит
Type: GET

Parameters:

device-token: унікальний ідентифікатор пристрою, що зберігається між сесіями.
Відповідь
У відповідь сервер повертає JSON об'єкт з ключем "price" та значенням однієї з наступних опцій:

10 (75%)
20 (10%)
50 (5%)
5 (10%)
Вимоги та обмеження
Якщо девайс одного разу отримав значення, то він завжди отримуватиме лише його.
Експеримент проводиться тільки для нових девайсів: якщо експеримент створений після першого запиту від девайсу, то девайс не повинен нічого знати про цей експеримент.
