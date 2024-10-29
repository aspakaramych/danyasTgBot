using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

class Program
{
    private static ITelegramBotClient _client;
    private static ReceiverOptions _options;
    
    static async Task Main()
    {
        _client = new TelegramBotClient("7846655681:AAG4onxJkYwXyq0jBewe86wMRW0bjgROMTM");
        _options = new ReceiverOptions
        {
            AllowedUpdates = new []
            {
                UpdateType.Message,  
            },
            ThrowPendingUpdates = true,
        };
        using var cts = new CancellationTokenSource();
        _client.StartReceiving(UpdateHandler, ErrorHandler, _options, cts.Token);
        var me = await _client.GetMeAsync();
        Console.WriteLine($"{me.FirstName} запущен");
        await Task.Delay(-1);
    }

    private static async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken ct)
    {
        try
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                {
                    var message = update.Message;

                    // From - это от кого пришло сообщение
                    var user = message.From;
                    
                    // Выводим на экран то, что пишут нашему боту, а также небольшую информацию об отправителе
                    Console.WriteLine($"{user.FirstName} ({user.Id}) написал сообщение: {message.Text}");

                    // Chat - содержит всю информацию о чате
                    var chat = message.Chat;
                    switch (message.Type)
                    {
                        case MessageType.Text:
                        {
                            switch (message.Text)
                            {
                                case "/start":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    using Stream stream = System.IO.File.OpenRead("../../../photos/startPhoto.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(stream, "startPhoto.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Привет, дорогой путешественник!\ud83d\udc4b\ud83c\udffb Готовься! Нас ждёт увлекательное путешествие! \n\nМы едем, а куда мы едем? \nВедь вокруг так много интересного, можно просто растеряться от выбора. \ud83d\udd0d Наверное, так многие задумываются в растерянности, как бы не пропустить самого интересного места для путешествия \ud83d\uddfa \n\nИ я, нерпенок Субади, решил помочь всем, кто захочет познакомиться с великим озером Байкал. Моё имя уже говорит за себя, Субади - это бурятское имя, означающее «Байкальская Жемчужина»! \nЧат-бот «7 чудес Байкала» просто необходим для виртуального путешествия по озеру Байкал  в условиях пандемии!",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "1 этап «Карта-путеводитель»":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    using Stream stream = System.IO.File.OpenRead("../../../photos/firstPhoto.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(stream, "firstPhoto.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Субади: \"Ребята! Вы представляете, мои друзья на дне Байкала нашли карту-путеводитель, на которой изображён маршрут нашего путешествия! Так... Целых 7 станций! А ну, помогайте разглядеть!\ud83d\udc40\ud83d\uddfa»",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "2 этап «Кругобайкальская железная дорога»":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "А вот и первое чудо Байкала: «Кругобайкальская железная дорога»! Давайте подробнее рассмотрим ее!\n\n\ud83d\udd3ahttps://www.youtube.com/watch?v=hvJK4-6-LPU\n\nP.S. Это путешествие в формате 360 градусов! Вращай телефон и любуйся необыкновенными видами!\ud83d\udcf1\ud83d\ude82\nНу что, поехали?! Ту-тууу….\n\nСамое прекрасное в любом путешествии на поезде — сесть у окна и под мерный успокаивающий стук колёс наблюдать, как один пейзаж сменяет другой. А теперь представьте, что поезд движется по побережью одного из самых красивых озёр планеты; за окном не просто поля и леса, а обрывистые скалы, горные распадки, живописные реки и заводи, уникальные тоннели и милые деревянные домики. Это не картинка из фильма, а чудо инженерной мысли конца XIX века — Кругобайкальская железная дорога.\n\nРасположение: Иркутская область, Слюдянка – Порт Байкал\nПротяжённость: 89 км от ст. Байкал до ст. Слюдянка II\n \nИнтересные факты: \n\ud83d\udd3ahttps://youtu.be/1ZrnP3Tt6yk             \ud83d\udd3ahttps://visit-baikal.info/mesta/krugobajkalskaya-zheleznaya-doroga",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "3 этап «Остров Ольхон»":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Итак, второе чудо\nБайкала, его сердце - остров Ольхон.\nЮные туристы! Вы можете пройтись в густых лесах на восточном побережье, увидеть суровые мраморные скалы и песчаные пляжи с дюнами на западе, голые степи. Пейзажи дикой природы Ольхона красивы и величественны, в этом можете убедиться  вы сами! \u26f0\ud83c\udf33\n\nВидео сюжеты: \n\ud83d\udd3ahttps://youtu.be/kFpV_1WAsqE\n\ud83d\udd3ahttps://youtu.be/iW4sHfLBUIg\n\ud83d\udd3a http://surl.li/bdsqd\n\u2757\ufe0fХочешь познакомиться с этим островом поближе? Тогда смотри историю Ольхона, незабываемые места и интересные факты: \n\ud83d\udd3ahttps://posibiri.ru/26-interesnyx-faktov-ob-ostrove-olxon/\n\ud83d\udd3a http://www.baikaltur.com/articles/olkhon",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "4 этап «Город Байкальск»":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Едем дальше, третье чудо Байкала - уникальный город Байкальск, в котором можно отдыхать круглый год.\nЗдесь вас ждут три экскурсии.\n\u25aa\ufe0f1 экскурсия на Горе Соболиной. Турист может виртуально подняться на гору по канатной дороге, а спуститься на горных лыжах.\u26f7\ud83c\udfd4\n\u25aa\ufe0f2 экскурсия к скульптуре «Ухо Байкала». Говорят, что если загадать ему желание, оно обязательно сбудется! Поэтому наши путешественники могут загадать своё желание в онлайн -  \"Ухо\". \n\u25aa\ufe0f3 экскурсия приведёт нас на фестиваль клубники! Тут мы можем вырастить виртуальную клубнику, побывать на мастер-классе по созданию душистого варенья \ud83c\udf53\ud83d\udc50\ud83c\udffb\n \n\u2757\ufe0fИнтегративные ссылки: \n\n\ud83d\udd3ahttps://youtu.be/YAABA-Ri0YI\n\ud83d\udd3ahttps://youtu.be/4afhKKQwxfE\n\ud83d\udd3ahttps://youtu.be/Gq9Se4bObGM\n\ud83d\udd3ahttps://youtu.be/i5612JVIgbY\n\ud83d\udd3a https://youtu.be/K9Agl598PWk\n\ud83d\udd3a https://youtu.be/dIfChelcUE8\n\ud83d\udd3a https://youtu.be/VVCBYDUYckc\n\ud83d\udd3a https://youtu.be/K9Agl598PWk\n \n\u2757\ufe0fИнтернет-экскурсия, от лидеров РДШ г.Саянска, в город Байкальск:\n\n\ud83d\udd3ahttps://disk.yandex.ru/i/PAmDZDtBEb9bSg",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "5 этап «Город Слюдянка»":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Субади: «Ребята! А вы знали, что место, откуда я родом, является важным  Российским центром по добыче различных минералов, самоцветов и полезных ископаемых!».\ud83d\udc8e\ud83d\udc40\n Это город Слюдянка, и мы отправляемся в туда. Здесь нас ждёт геологический музей-онлайн «Самоцветы России», где вы сможете посмотреть более трёх сотен различных минералов!\n\n\u25aa\ufe0f http://surl.li/bdsqi\n\u25aa\ufe0f https://youtu.be/S3-5cJZU7n0\n\u25aa\ufe0f http://surl.li/bdsqj\n\u25aa\ufe0f http://baikalgem.ru/static/museum.html\n\u25aa\ufe0f http://surl.li/bdsqc",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "6 этап «Байкальский заповедник»":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Субади: «А вот и мои друзья! Давайте с ними поближе познакомимся?!»\ud83d\udc17\ud83d\udc07\nИ с ними мы отправляемся к следующему чуду Байкала - Байкальский заповедник. Это крупный заповедник и занимает центральную часть Хамар-Дабана. Общая площадь заповедной территории составляет 165 724 га! По заповеднику проложено несколько туристических троп, которые смогут посетить туристы. Гуляя по заповеднику, пользователи могут увидеть и услышать всех обитателей и эндемиков.\ud83c\udf32\ud83e\uddab\n\nОнлайн экскурсии:\n\ud83d\udd3a https://youtu.be/PLeiI3fd2vs\n\ud83d\udd3a https://youtu.be/dKMnkx0_18c\n\ud83d\udd3a https://youtu.be/DYkSixKkD-A\n\ud83d\udd3a https://gotonature.ru/1785-bajkalskij-zapovednik.html\n\ud83d\udd3a https://youtu.be/g46OxiIJf_4\n\ud83d\udd3a http://baikalake.ru/tour/",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "7 этап «Листвянка»":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "На шестой станции наших туристов ждет посёлок Листвянка.\ud83d\uddfa\ud83c\udf92\nВы можете посетить:\n1. Свято-Никольскую церковь\n2. Шаман-камень\n3. Нерпинарий\nи другие достопримечательности.                      Проехав дальше, мы можем посетить этнографический музей «Тальцы». Он находится под открытым небом. На его территории воссозданы деревни и поселения народностей Байкала.\ud83c\udfd5\n\ud83d\udd3ahttps://talci-irkutsk.ru/virtualnye-ekskursii                   \n\ud83d\udd3ahttps://youtu.be/lIjvBNuCGo0                                             \ud83d\udd3ahttps://youtu.be/Gg2w2jCsmdo                                             \ud83d\udd3ahttps://youtu.be/l2LiwARfbis                                                                \nЛиствянка - посёлок в Иркутской области у истока Ангары: это самое популярное место на Байкале, откуда начинаются и пешие походы вдоль берега, и водные маршруты по озеру. \ud83c\udfde\n\ud83d\udef6Еще, это самое удобное место для встречи с Байкалом. Местность тут и правда красивая: к Байкалу вплотную подходят горы. В хорошую погоду здешний ландшафт действительно напоминает какое-нибудь южное побережье (Чехов, например, сравнивал эти места с Крымом) с поправкой на дующий с озера прохладный ветер. Микроклимат Листвянки — едва ли не самый комфортный в Восточной Сибири. Летом нежарко, а зима мягче, чем в Иркутске.\u2600\ufe0f\ud83c\udf43                                                                            \ud83d\udd3ahttps://youtu.be/uglHW_CuihI                                                              \ud83d\udd3ahttps://youtu.be/fOiEMZggs64                                                                  \ud83d\udd3ahttps://youtu.be/0OqcBdof7sE                                                               \ud83d\udd3ahttps://youtu.be/itzbj8mE9sc                                                             \ud83d\udd3ahttps://youtu.be/HQFy90AaPwc                                                         \ud83d\udd3ahttps://youtu.be/UGDCEwJVZlg                                                                 \ud83d\udd3ahttps://youtu.be/JQDzw4qGTks                                                        \ud83d\udd3ahttps://youtu.be/uiaABqvvG9c                                                             \ud83d\udd3ahttps://youtu.be/A6YoSSa-L0U                                                           \ud83d\udd3ahttps://youtu.be/BBoEjHtGHzI                                                                \ud83d\udd3ahttps://youtu.be/-UnYNHsGa_c                                                              \ud83d\udd3ahttps://youtu.be/lBtLkzpvD2o                                                            \ud83d\udd3ahttps://youtu.be/UJZy1j2kRgM                                                        \ud83d\udd3ahttps://youtu.be/RDjPJ_47fNg                                                               \ud83d\udd3ahttps://youtu.be/7pZJTC7j1II                                                                    \ud83d\udd3ahttps://kuzuk.ru/3d/baikal/",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "8 этап «Посёлок Хужир»":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Субади: «А вот и заключительное, 7 чудо Байкала - посёлок Хужир. Туристы встретятся с жителями этого посёлка и смогут посмотреть на быт островитян, услышать байкальские легенды».                    \n\n\ud83d\udd3ahttps://youtu.be/Q7OFJN7ZPMk\n\ud83d\udd3a https://www.kinopoisk.ru/film/4299813/\n\ud83d\udd3a http://irkipedia.ru/content/mify_i_legendy_baykala\n\ud83d\udd3a https://youtu.be/Y15jjVj8LmQ",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "ПОДБОРКА ЭКСКУРСИЙ\ud83c\udfd5":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Субади: «А тут я собрал для Вас самые масштабные, удивительные онлайн - экскурсии!»\ud83d\udcf1\ud83c\udfde\n\ud83d\udd3a http://baikalake.ru/tour/\n\ud83d\udd3ahttps://kuzuk.ru/3d/baikal/",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "TRAVEL-САЙТЫ \ud83c\udf43(забронировать экскурсию)":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "А где же можно забронировать туры для реального посещения Байкала? \ud83c\udfd5\ud83d\udcb5\n\u2757\ufe0fА вот и наша подборка:\n\n\u25aa\ufe0f http://surl.li/bdssb\n\u25aa\ufe0f https://zapovednoe-podlemorye.ru/travel/excursions/\n\u25aa\ufe0f https://magput.ru/?id=1466\n\u25aa\ufe0f https://baikal-nord.ru/search-tours/huzhir\n\u25aa\ufe0f https://www.kp.ru/russia/bajkal/tury/virtualnye/\n\u25aa\ufe0f https://www.sputnik8.com/ru/baikal\n\u25aa\ufe0f http://surl.li/bdsvl",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "АВТОРЫ И СОАВТОРЫ\ud83c\udfa4":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Поговорим о наших авторах и соавторах\ud83d\udc40\ud83c\udfa4\nА именно:\n\u25aa\ufe0fУчуватова Валерия, 15 лет, г. Саянск (уже 17 лет \ud83d\ude01)\n\u2757\ufe0fСоздатель чат-бота, автор концепции проекта, логотипа и сувенирной продукции\n\u25aa\ufe0fМуратова Лола Абдурахманова, г. Саянск\n\u2757\ufe0fНаставник\n\u25aa\ufe0fГлавный гид-путешественник -  нерпёнок Субади \n\u2757\ufe0fПерсонаж, без которого, проект был бы совсем не таким сказочным и интересным",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "ПРОЕКТ ЛИДЕРОВ РДШ Г. САЯНСКА «ГОРОД БАЙКАЛЬСК»":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Лидеры РДШ г. Саянска приняли участие в саммите, посвящённому году Байкала, и подготовили видео-проект «Город Байкальск моими глазами»\nПриятного просмотра \ud83c\udfac\ud83c\udf7f\n\nhttps://disk.yandex.ru/i/PAmDZDtBEb9bSg",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "ПРИМЕЧАНИЕ АВТОРА\ud83d\udcdc\ud83e\udeb6":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Примечание автора:\ud83e\udeb6\ud83d\udcdc\nЯ - юная сибирячка и во мне живет дух Байкала, и я хочу, чтобы он пробудился в каждом туристе!  Ведь во время пандемии странствовать стало намного труднее, но я придумала решение, это мой чат-бот, который даёт возможность путешествовать не выходя из дома! \ud83d\udcf1\ud83d\uddfa\n\np.s. Надеюсь, Байкал \"поглотит\" вас своей красотой\ud83c\udf0a",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "ИГРОТЕКА\ud83c\udfae":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "А для того, чтобы действительно  сблизиться с Байкалом и просто увлекательно провести своё время, мы предлагаем вам нашу игротеку: \ud83c\udfae\ud83d\udd8c\n\u25aa\ufe0fигры, викторины о Байкале:\n\ud83d\udd3a http://xn--80aaabarha2bkm1gb8f.xn--p1ai/\n\ud83d\udd3a http://surl.li/bdzpi\n\ud83d\udd3a https://kupidonia.ru/viktoriny/test-po-geografii-ozero-baykal-chto-vy-znaete-o-nem\n\u25aa\ufe0fраскраски с эндемиками, обитателями, растениями Байкала : \n\ud83d\udd3a http://surl.li/bdzpj\n\u25aa\ufe0fфильмы о Байкале: \n\ud83d\udd3a http://surl.li/bdzpl\n\ud83d\udd3a https://www.kino-teatr.ru/kino/movie/sov/8738/annot/\n\ud83d\udd3a https://www.kinopoisk.ru/film/4299813/\n\ud83d\udd3a https://www.kinopoisk.ru/film/1301681/\n\ud83d\udd3a https://www.kinopoisk.ru/film/1009742/\n\ud83d\udd3a https://www.kino-teatr.ru/doc/movie/ros/125477/annot/\n\ud83d\udd3a https://www.kinopoisk.ru/film/910536/\n\u25aa\ufe0fпазлы с пейзажами Байкала:\n\ud83d\udd3a https://puzzleit.ru/puzzles/view/241776",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "БАЙКАЛЬСКАЯ КНИЖНАЯ ПОЛКА\ud83d\udcda":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Но эти царственные воды, Но горы в сизой полумгле, ― Байкал ― бесценный дар природы ― Да будет вечен на земле! \ud83c\udf0a\ud83c\udf0e\n \nИ вправду мы уже достаточно сблизились с нашим великим озером - богатырем! И теперь мы предлагаем вам «Байкальскую золотую книжную полку», здесь вас ждут:\n\u25aa\ufe0fМифы, легенды, сказки Байкала:\n\ud83d\udd3a https://www.culture.ru/materials/198868/mify-i-legendy-o-baikale\n\ud83d\udd3a https://podparusami.club/bajkal-mify-i-legendy-samogo-glubokogo-ozera-na-planete/\n\ud83d\udd3a http://irkipedia.ru/content/mify_i_legendy_baykala\n\ud83d\udd3a https://youtu.be/Y15jjVj8LmQ\n\ud83d\udd3a https://po-baikalu.ru/blog/interesting-facts/mify-i-legendy/\n\ud83d\udd3a https://youtu.be/jiNjTVSfGsY\n\n\u25aa\ufe0fЛитературные произведения,  посвящённые Байкалу:\n\ud83d\udd3aВ тайге, над Байкалом\nВалентин Распутин \n\ud83d\udd3aБайкала-озера сказки\nКнига, Г. А. В. Траугот и Н Есипенок\n\ud83d\udd3aБайкал в вопросах и ответах\nКнига, Григорий Иванович Галазий\n\ud83d\udd3aСказки озера Байкал\nКнига, Василий Пантелеймонович Стародумов\n\ud83d\udd3aПо Байкалу\nКнига, Сергей Волков\n\ud83d\udd3aВокруг Байкала за 73 дня\nКнига, Эрик Юрьевич Бутаков\n\ud83d\udd3aSacred Sea\nКнига, Питер Томсон\n\ud83d\udd3aЧто в имени твоем, Байкал?\nКнига, Станислав Андреевич Гурулёв\n\ud83d\udd3aГод чуда и печали: повести\nПовесть, Леонид Иванович Бородин\n\ud83d\udd3aМир Байкала\nКнига, Станислав Иосифович Гольдфарб\n\ud83d\udd3aНа электричках до Байкала. Колоритные попутчики, душевные разговоры и 5000 км за 13 дней\nКнига, Алексей Абанин\n\ud83d\udd3aОзеро Байкал. Популярно о великом\nКнига, Сборник\n\ud83d\udd3aВоенные моряки Байкала: проблемы исторической реконструкции деятельности военных моряков Российского флота по физико-географическому изучению и освоению озера Байкал в ХVIII-ХХ вв\nКнига, Леонид Григорьевич Колотило\n\n\u25aa\ufe0fПодборка (топ 20 книг о Байкале):\n\ud83d\udd3ahttps://www.livelib.ru/selection/15958-bajkal\n\n\u25aa\ufe0fЖурнал «Сибирячок»\n\ud83d\udd3ahttps://sibiryachok.net/page17364800.html",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                                case "СУВЕНИРНАЯ ПРОДУКЦИЯ\ud83e\ude86\ud83c\udf0a":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    using Stream logo = System.IO.File.OpenRead("../../../photos/productLogo.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(logo, "productLogo.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Дорогие туристы! \ud83c\udfd5\ud83d\uddfa \nМы надеемся вам понравилось наше виртуальное путешествие! А теперь предлагаем вам приобрести сувенирную продукцию с нашим логотипом:\n\nP.S. По вопросам приобретения нашей сувенирной продукции просьба обращаться по контактному телефону 89025437770 \ud83d\udcf1\ud83d\udc40 (Менеджер - Валерия)",
                                        replyMarkup: replyKeybord);
                                    using Stream shopper = System.IO.File.OpenRead("../../../photos/shopper.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(shopper, "shopper.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Шопер (эко-сумка)\n750 руб");
                                    using Stream mayka = System.IO.File.OpenRead("../../../photos/mayka.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(mayka, "mayka.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Белая футболка с логотипом \n890 руб");
                                    using Stream znacok = System.IO.File.OpenRead("../../../photos/znacok.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(znacok, "znacok.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Значок \n50 руб");
                                    using Stream switshot = System.IO.File.OpenRead("../../../photos/svitshot.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(switshot, "svitshot.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Свитшот \n1250 руб");
                                    using Stream pazl = System.IO.File.OpenRead("../../../photos/pazl.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(pazl, "pazl.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Пазл с логотипом \n350 руб");
                                    using Stream kovrik = System.IO.File.OpenRead("../../../photos/kovrik.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(kovrik, "kovrik.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Коврик для мышки \n250 руб");
                                    using Stream bottle = System.IO.File.OpenRead("../../../photos/bottle.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(bottle, "bottle.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Бутылка для питья \n550 руб");
                                    using Stream tofallLogo = System.IO.File.OpenRead("../../../photos/tofallLogo.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(tofallLogo, "tofallLogo.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "А также продукция от еще одного нашего чат-бота: «Загадочный мир Тофаларии» \ud83d\udcab");
                                    using Stream tofallbottle = System.IO.File.OpenRead("../../../photos/tofallbottle.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(tofallbottle, "tofallbottle.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Бутылка для питья \n550 руб");
                                    using Stream padyshka = System.IO.File.OpenRead("../../../photos/padyshka.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(padyshka, "padyshka.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Чехол для подушки 35х35\n250 руб");
                                    using Stream tofallznac = System.IO.File.OpenRead("../../../photos/tofallznac.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(tofallznac, "tofallznac.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Значок \n50 руб");
                                    using Stream hudi = System.IO.File.OpenRead("../../../photos/hudi.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(hudi, "hudi.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Кофта-худи\n1500 руб");
                                    using Stream polo = System.IO.File.OpenRead("../../../photos/polo.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(polo, "polo.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Рубашка-поло\n1290 руб");
                                    using Stream tofallpazl = System.IO.File.OpenRead("../../../photos/tofallpazl.jpg");
                                    await client.SendPhotoAsync(
                                        chat.Id,
                                        photo: InputFile.FromStream(tofallpazl, "tofallpazl.jpg")
                                    );
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "Пазл с логотипом\n250 руб");
                                    return;
                                }
                                case "НАШИ ПАРТНЁРЫ\u2705":
                                {
                                    var replyKeybord = CreateReplyMarkup(); 
                                    await client.SendTextMessageAsync(
                                        chat.Id,
                                        "А вот и наш партнёр, Иосиф Иремашвили - автор чат-бота «Озеро желаний». Вместе с ним вы сможете посетить онлайн-экскурсию по озеру Байкал!\ud83c\udf0a\u2728\n\nhttps://t.me/Lake_Desires_bot",
                                        replyMarkup: replyKeybord);
                                    return;
                                }
                            }
                            return;
                        } 
                        default:
                        {
                            await client.SendTextMessageAsync(
                                chat.Id,
                                "Используй только текст!");
                            return;
                        }
                    }
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private static ReplyKeyboardMarkup CreateReplyMarkup()
    {
        var replyKeybord = new ReplyKeyboardMarkup(
            new List<KeyboardButton[]>()
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("1 этап «Карта-путеводитель»")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("2 этап «Кругобайкальская железная дорога»")   
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("3 этап «Остров Ольхон»")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("4 этап «Город Байкальск»")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("5 этап «Город Слюдянка»")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("6 этап «Байкальский заповедник»")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("7 этап «Листвянка»")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("8 этап «Посёлок Хужир»")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("ПОДБОРКА ЭКСКУРСИЙ\ud83c\udfd5")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("TRAVEL-САЙТЫ \ud83c\udf43(забронировать экскурсию)")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("АВТОРЫ И СОАВТОРЫ\ud83c\udfa4")    
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("ПРОЕКТ ЛИДЕРОВ РДШ Г. САЯНСКА «ГОРОД БАЙКАЛЬСК»")   
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("ПРИМЕЧАНИЕ АВТОРА\ud83d\udcdc\ud83e\udeb6")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("ИГРОТЕКА\ud83c\udfae")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("БАЙКАЛЬСКАЯ КНИЖНАЯ ПОЛКА\ud83d\udcda")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("СУВЕНИРНАЯ ПРОДУКЦИЯ\ud83e\ude86\ud83c\udf0a")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("НАШИ ПАРТНЁРЫ\u2705")  
                },
            })
        {
            ResizeKeyboard = false,
        };
        return replyKeybord;
    }
    private static Task ErrorHandler(ITelegramBotClient client, Exception error, CancellationToken ct)
    {
        var ErrorMessage = error switch
        {
            ApiRequestException apiRequestException =>
                $"Telegramm Bot Error:\n[{apiRequestException.ErrorCode}] \n {apiRequestException.Message}",
            _ => error.ToString()
        };
        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}