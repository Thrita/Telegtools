using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thrita.Telegtools.Test
{
    static class TestData
    {
        #region Text Post
        internal const string TextPost =
@"<!DOCTYPE html>
<html>
  <head>
    <meta charset=""utf-8"">
    <title>Telegram Widget</title>
    <base target= ""_blank"" >
    < meta name= ""viewport"" content= ""width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"" />
    < meta name= ""format-detection"" content= ""telephone=no"" />
    < meta http-equiv= ""X-UA-Compatible"" content= ""IE=edge"" />
    < meta name= ""MobileOptimized"" content= ""176"" />
    < meta name= ""HandheldFriendly"" content= ""True"" />
    < meta name= ""robots"" content= ""noindex, nofollow"" />


    < link rel= ""shortcut icon"" href= ""//telegram.org/favicon.ico?3"" type= ""image/x-icon"" />
    < link href= ""https://fonts.googleapis.com/css?family=Roboto:400,500"" rel= ""stylesheet"" type= ""text/css"" >
    < link href= ""//telegram.org/css/widget-frame.css?9"" rel= ""stylesheet"" media= ""screen"" >
    < script > TBaseUrl = '//telegram.org/';</script>
  </head>
  <body class=""tgme_widget body_widget_post emoji_default"">
    <div class=""tgme_widget_message"" id=""widget_message"" data-view=""eyJ0IjoxNTIxMTI2NzQ3LCJoIjoiMzBmODAyN2Y2MjBkMGNhYmZmIn0"">
  <div class=""tgme_widget_message_user""><a href = ""https://t.me/K1inUSA"" >< i class=""tgme_widget_message_user_photo bgcolor4"" data-content=""K""><img src = ""https://cdn4.telesco.pe/file/CpZLfa51Dvi8iH8Qf-9X5X6Y1fZCt46Sugd6ri68JPF8VgR3cVJh4fUaCsVMyikQtkMdxVtHb-R2-ZCKQAolKejYsk1dXRDfnx9mtpbn5j1PNxuJ0P1n2Fx4XdgFY6rl2i8J0fDFJm6Li525DjbD8fXizh6RB1gRmL6ovdeAavCILZdP5q2m6Mp_HBzYm-PmjKcaN3ljTz4LF4CUiYLF8u3W77oPrkXz_pxmJiCjjYZ4I8cJ7vqlGAEFih5MGizlhzSY4cjBqPR0GKI43B4quREtvHLIfec-UDRhVLFMDrxDAN-Sn3lxeqCas_dwy0IunCLq6gdKPONSnsUCnA2kKw.jpg"" ></ i ></ a ></ div >
    
      < div class=""tgme_widget_message_bubble"">
    <i class=""tgme_widget_message_bubble_tail"">
      <svg width = ""9px"" height=""20px"" viewBox=""0 0 9 20"">
        <g fill = ""none"" >
          < path class=""background"" fill=""#fff"" d=""M1.29,0 L9,0 L9,20 L7,20 L7,17.411 C7,14.298 6.413 11.233 5.24 8.218 C4.336 5.893 2.794 3.733 0.614 1.738 L0.614 1.738 C0.207 1.365 0.179 0.732 0.552 0.325 C0.741 0.118 1.009 0 1.29 0 Z""/>
          <path class=""border"" stroke=""#d7e3ec"" stroke-width=""1"" d=""M9,0.5 L1.29,0.5 C1.149,0.5 1.015 0.559 0.921 0.662 C0.734,0.866 0.748 1.182 0.952 1.369 C3.186,3.414 4.772 5.637 5.706 8.036 C6.902,11.109 7.5 14.235 7.5 17.411 L7.5,20""/>
        </g>
      </svg>
    </i>
    <div class=""tgme_widget_message_author""><a class=""tgme_widget_message_owner_name"" href=""https://t.me/K1inUSA""><span dir = ""auto"" > K1 in USA</span></a></div>



<div class=""tgme_widget_message_text"" dir=""auto"">مدیریت زمستانی به روش انگلیسی<br/><br/>#یادداشت_مهمان<br/>#دکتر_بهروز_ثقفی، ساکن انگلیس<br/>بخش ۱ از ۳<br/><br/>خب بالاخره طوفان و بوران به سر رسید و شاید الآن بشه یه نگاه به عقب کرد و دید در کشوری که ادعای عَلَم‌داری در تکنولوژی و مدیریت داره یه طوفان سه چهار روزه چطور مدیریت (&#33;) شده.<br/><br/>حداقل از دوشنبه ۲۶ فوریه بود که Met Office یا همون سازمان هواشناسی انگلیس جدی جدی شروع کرد به انتشار اطلاعیه و اخطار که هوا می‌خواد سرد بشه، قراره که برف درست و حسابی بباره، طوفان در پیش رو داریم و أیها الناس، آماده باشید.  حتی تا اینجای قضیه رو فرمود که دما شدید می‌افته به حول و حوش پنج درجه زیر صفر ولی به دلیل باد سردی که همراه این موج داره میاد، جماعت احساس دمای ۱۰- تا ۱۵- رو خواهند داشت. حجم برف رو هم از پنج سانت در سطح دریا تا ۱۵ سانت در ارتفاعات پیش‌بینی کرده بود. حتی ناصحانی هم اومدن توی رادیو از مردم خواستن که کِنِسی رو کنار بگذارن و کمی شیر شوفاژ رو بیشتر وا کنن و شاخص دستگاه تنظیم‌کننده‌ی دمای منزل رو روی دمای بالاتری قرار بدن. چون ضرر افزایش هزینه‌های انرژی‌شون به مراتب کمتر از ضررهای ناشی از بیمار شدن هست.<br/><br/>داستان از این قراره که یه موج سرمای پر فشار که توپ‌ش توی سیبری پر شده بود، سرش رو خم کرده بود سمت اروپا و گازشو گرفته بود تا یه حالی از اروپا‌نشینان نگیره، بی‌خیال نشه. از سه‌شنبه شب دما به شدت افتاد ولی دیگه چهارشنبه بود که هوا رسماً قاطی کرد؛ برف و طوفان با هم. گر چه سابقاً اخبار چنین وضعی در شهرهای دیگه از جمله لندن رو از طریق رسانه‌ها شنیده و دیده بودم، یه همچین وضعی رو خودم توی شهرهایی که توشون زندگی کردم لمس نکرده بودم و از نزدیک با تبعات ظهور و بروز چنین طوفانی برخورد نداشتم.<br/><br/>طبیعتاً با اون همه اخطار و اعلان پیشاپیش به اضافه‌ی این همه دک و پُز مدیریت در انگلستان و صدها هزار صفحه قوانین Health and Safety، کمترین انتظاری که داری اینه که صبح چارشنبه که می‌خوای بزنی بیرون، شهرداری حداقل یه پاکت شن نمک روی کف خیابونا و پیاده‌روها ریخته باشه؛ یه فکری به حال فرودگاه‌ها کرده باشه که بسته نشن به خاطر چهار پنج سانت برف؛ یه دو تا اتوبوس داخل شهری اضافی در نظر گرفته باشه (با این همه تبلیغی که برای استفاده‌ی مردم از حمل‌ونقل عمومی توی بوق و کرنا می‌کنه) تا مردم کنار خیابون یخ نزنن. اما اگه شما دیدید که یه همچین کاری رو مدیران شهری منچستر، دومین شهر بزرگ انگلستان، در «سال مهندسی» کرده باشن، مام دیدیم.<br/><br/>ادامه دارد...<br/><br/>مشاهدات و روزنوشته‌های دانشجویان و دانش‌آموختگان مسلمان ایرانی<i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87AEF09F87B7.png')""><b>🇮🇷</b></i> از امریکا<i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87BAF09F87B8.png')""><b>🇺🇸</b></i><br/><a href=""https://t.me/K1inUSA"" target=""_blank"">@K1inUSA</a></div>

<div class=""tgme_widget_message_footer"">
<div class=""tgme_widget_message_link"">
  <a href = ""https://t.me/K1inUSA/5340"" class=""link_anchor flex_ellipsis""><span class=""ellipsis"">t.me/K1inUSA</span>/5340</a>
</div>
<div class=""tgme_widget_message_info"">
  <span class=""tgme_widget_message_views"">10.3K</span><span class=""copyonly""> views</span><span class=""tgme_widget_message_meta""><span class=""tgme_widget_message_from_author"" dir=""auto"">کیوان ابراهیمی</span>,&nbsp;<a class=""tgme_widget_message_date"" href=""https://t.me/K1inUSA/5340""><time datetime = ""2018-03-13T05:20:28+00:00"" > Mar 13 at 05:20</time></a></span>
</div>
</div>
  </div>
</div>
    
    <script src = ""//telegram.org/js/widget-frame.js?17"" ></ script >
    < script > (function(i, s, o, g, r, a, m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function()
        {
            (i[r].q = i[r].q ||[]).push(arguments)},i[r].l=1*new Date(); a=s.createElement(o),
m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a, m)
    })(window, document,'script','//www.google-analytics.com/analytics.js','ga');

ga('create', 'UA-45099287-3', 'auto', { 'sampleRate': 5});
ga('send', 'pageview'); TWidgetPost.init('widget_message');
</script>
  </body>
</html>
<!-- page generated in 13.97ms -->
";
        #endregion

        #region Text Reply Post


        internal const string TextReplyPost =
@"
<!DOCTYPE html>
<html>
  <head>
    <meta charset=""utf-8"">
    <title>Telegram Widget</title>
    <base target= ""_blank"" >
    < meta name= ""viewport"" content= ""width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"" />
    < meta name= ""format-detection"" content= ""telephone=no"" />
    < meta http-equiv= ""X-UA-Compatible"" content= ""IE=edge"" />
    < meta name= ""MobileOptimized"" content= ""176"" />
    < meta name= ""HandheldFriendly"" content= ""True"" />
    < meta name= ""robots"" content= ""noindex, nofollow"" />


    < link rel= ""shortcut icon"" href= ""//telegram.org/favicon.ico?3"" type= ""image/x-icon"" />
    < link href= ""https://fonts.googleapis.com/css?family=Roboto:400,500"" rel= ""stylesheet"" type= ""text/css"" >
    < link href= ""//telegram.org/css/widget-frame.css?9"" rel= ""stylesheet"" media= ""screen"" >
    < script > TBaseUrl = '//telegram.org/';</script>
  </head>
  <body class=""tgme_widget body_widget_post emoji_default"">
    <div class=""tgme_widget_message"" id=""widget_message"" data-view=""eyJ0IjoxNTIxMTMyNzM1LCJoIjoiY2ZhNGIxMGE4NmFkMjNjY2MwIn0"">
  <div class=""tgme_widget_message_user""><a href = ""https://t.me/K1inUSA"" >< i class=""tgme_widget_message_user_photo bgcolor4"" data-content=""K""><img src = ""https://cdn4.telesco.pe/file/CpZLfa51Dvi8iH8Qf-9X5X6Y1fZCt46Sugd6ri68JPF8VgR3cVJh4fUaCsVMyikQtkMdxVtHb-R2-ZCKQAolKejYsk1dXRDfnx9mtpbn5j1PNxuJ0P1n2Fx4XdgFY6rl2i8J0fDFJm6Li525DjbD8fXizh6RB1gRmL6ovdeAavCILZdP5q2m6Mp_HBzYm-PmjKcaN3ljTz4LF4CUiYLF8u3W77oPrkXz_pxmJiCjjYZ4I8cJ7vqlGAEFih5MGizlhzSY4cjBqPR0GKI43B4quREtvHLIfec-UDRhVLFMDrxDAN-Sn3lxeqCas_dwy0IunCLq6gdKPONSnsUCnA2kKw.jpg"" ></ i ></ a ></ div >
    
      < div class=""tgme_widget_message_bubble"">
    <i class=""tgme_widget_message_bubble_tail"">
      <svg width = ""9px"" height=""20px"" viewBox=""0 0 9 20"">
        <g fill = ""none"" >
          < path class=""background"" fill=""#fff"" d=""M1.29,0 L9,0 L9,20 L7,20 L7,17.411 C7,14.298 6.413 11.233 5.24 8.218 C4.336 5.893 2.794 3.733 0.614 1.738 L0.614 1.738 C0.207 1.365 0.179 0.732 0.552 0.325 C0.741 0.118 1.009 0 1.29 0 Z""/>
          <path class=""border"" stroke=""#d7e3ec"" stroke-width=""1"" d=""M9,0.5 L1.29,0.5 C1.149,0.5 1.015 0.559 0.921 0.662 C0.734,0.866 0.748 1.182 0.952 1.369 C3.186,3.414 4.772 5.637 5.706 8.036 C6.902,11.109 7.5 14.235 7.5 17.411 L7.5,20""/>
        </g>
      </svg>
    </i>
    <div class=""tgme_widget_message_author""><a class=""tgme_widget_message_owner_name"" href=""https://t.me/K1inUSA""><span dir = ""auto"" > K1 in USA</span></a></div>

<a class=""tgme_widget_message_reply"" href=""https://t.me/K1inUSA/5340"">
  
  <div class=""tgme_widget_message_author"">
    <span class=""tgme_widget_message_author_name"" dir=""auto"">K1 in USA</span>
  </div>
  <div class=""tgme_widget_message_text"" dir=""auto"">مدیریت زمستانی به روش انگلیسی  #یادداشت_مهمان #دکتر_بهروز_ثقفی، ساکن انگلیس بخش ۱ از ۳  خب بالاخره طوفان و بوران به سر رسید و شاید الآن بشه یه نگاه به عقب کرد و دید در کشوری که ادعای عَلَم‌داری در تکنولوژی و مدیریت داره یه طوفان سه چهار روزه چطور مدیریت (&#33;)…</div>
</a>

<div class=""tgme_widget_message_text"" dir=""auto"">مدیریت زمستانی به روش انگلیسی<br/><br/>#یادداشت_مهمان<br/>#دکتر_بهروز_ثقفی، ساکن انگلیس<br/>بخش ۲ از ۳<br/><a href=""https://t.me/K1inUSAMultiMedia/45"" target=""_blank"" rel=""noopener"">https://t.me/K1inUSAMultiMedia/45</a><br/><br/>و اما اون‌چه که اتفاق افتاد بر اساس گزارش‌های بی‌بی‌سی:<br/><br/>یک ترافیک وحشتناک در شهر که مسیرهای ۱۵ دقیقه‌ای و عادی داخل شهر رو کرده بود یک ساعت. از طرفی چون کارمند‌ان مهدکودک‌ها به موقع نرسیدن سر کار و اون یه کارمندی که توی مهدکودک هست میگه نمی‌تونه مسئولیت بیشتر از ده تا بچه رو به تنهایی قبول کنه، والدین باید صبر پیشه کنن تا سایرین از کارمندان هم برسن و بتونن بچه رو تحویل بدن. یه عده هم سر کار منتظر ورود همینایی هستن که الآن توی مهدکودک گرفتار شدن.<br/><br/>توی هر خیابونی چند تا ماشین به هم زدن و چون رانندگی این جماعت هم در سطح حرفه‌ای هست (&#33;) و زمین هم لغزنده، طرف ماشین‌ش رو رد نمی‌کنه که چند صد متر ترافیک پشتی حداقل یه ماشین جلوتر بره.<br/><br/>ایستگاه‌های اتوبوس مملو از جمعیت هست، از دور شبیه تجمعات کارگرهایی هست که حقوق‌شون ماه‌هاست عقب‌افتاده.  همه که زیر سایه‌بون یک متر در دو متر ایستگاه اتوبوس جا نمی‌شن که. عموم جماعت زیر برف وایسادن و گاه تا وسط خیابون میان ببینن از سمت افق دود اتوبوسی چیزی می‌بینن یا نه. یکی از دوستان که در بین اون جماعت بوده تعریف می‌کرد که یکی از شهروندان با اون شماره تلفنی که جهت تماس با سازمان اتوبوس‌رانی Stagecoach در ایستگاه درج شده تماس گرفت و چند جمله‌ای که مملو از عبارات عرفانی بود که با حرف F شروع می‌شدن، با اون‌ور خط درددل کرد.<br/><br/>عموم خودروها مجهز به سامانه‌ی گاه بسیار هوشمند ABS هستن ولی چرا روی شیب عرضی خیابون‌ها این ترمز جواب نمی‌داد، نمی‌دونم&#33;<br/><br/>چون چاله‌های آسفالت خیابون‌های محلی هم پر از برف بود و به سختی میشد تشخیص داد محل حضور اون چاله‌ها رو، گهگداری صدای برخورد شاسی خودروها به کف خیابون رو می‌شد شنید&#33; (در مورد چاله‌هایی به عمق تاریخ بعضی خیابون‌ها بعداً خدمت می‌رسم)<br/><br/>سابق بر این، می‌رفتی ایستگاه قطار در کشور Railway Kingdom و اگه هوا بد بود و از قبل بلیطی هم خریده بودی و خط ریل بسته بود به خاطر فقط چند سانت برف (&#33;)، شکایت می‌کردی و یا با اتوبوس جابجات می‌کردن یا بهت جریمه می‌دادن. امسال شرکت Network Rail پیش‌دستی کرد و بالای ۱۴۰۰ سرویس ریلی ر از سه‌شنبه شب تعطیل کرد و مدیرش نشست با خیال راحت کاپوچینوی قندپهلو رو نوش جان کرد. اصلاً کی گفته نماد حمل‌ونقل انگلستان باید خطوط ریلی بی توقف و کشورْ شمول اون باشن، ها؟&#33;<br/><br/>خیلی‌ها هم از بیخ سر کار نرفتن و با هر جا تماس می‌گیری، کمبود نیرو دارن یا دیر تشریف میارن سر کار یا به دلیل دورکاری انجام کارها بسیار کند خواهد بود.<br/><br/>توضیحات عکس‌ها:<br/>- اختلال در حمل و نقل کالا موجب کمبود مواد غذایی اولیه در فروشگاه‌ها شده<br/>- کمبود سبزیجات در فروشگاه‌ها<br/>مسافری ۱۴ ساعت در قطار گرفتار بوده و فقط با یک بطری آب رایگان ازش پذیرایی شده<br/>- گذراندن یک شب در قطار گرفتار در برف<br/>- گرفتار شدن مردم در قطار گیر کرده در برف و سپری کردن ساعت‌های طولانی در قطار<br/>- متأثر شدن فرودگاه‌های انگلستان<br/>- گرفتاری خودروها و کامیون‌ها در برف<br/>- تأخیر مأمورین شهرداری در جمع‌آوری زباله‌ها و پخش شدن سطل‌ها به دلیل باد شدید<br/>- اطلاعیه سازمان هواشناسی: همه‌ی سفرها به نوعی مختل خواهند شد<br/>- تعطیلی موقت فرودگاه دابلین<br/>- درخواست از ارتش برای کمک‌رسانی<br/>- صدها خودرو توی برف گیر کردن<br/>- زایمان در خودروی گیر افتاده در برف<br/><br/>عکس‌های تکی و واضح را از اینجا <a href=""https://t.me/K1inUSAMultiMedia/46"" target=""_blank"" rel=""noopener"">https://t.me/K1inUSAMultiMedia/46</a> تا اینجا <a href=""https://t.me/K1inUSAMultiMedia/59"" target=""_blank"" rel=""noopener"">https://t.me/K1inUSAMultiMedia/59</a> ببینید.<br/><br/>ادامه دارد...<br/><br/>مشاهدات و روزنوشته‌های دانشجویان و دانش‌آموختگان مسلمان ایرانی<i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87AEF09F87B7.png')""><b>🇮🇷</b></i> از امریکا<i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87BAF09F87B8.png')""><b>🇺🇸</b></i><br/><a href=""https://t.me/K1inUSA"" target=""_blank"">@K1inUSA</a></div>
<a class=""tgme_widget_message_link_preview"" href=""https://t.me/K1inUSAMultiMedia/45"">
  
  <div class=""link_preview_site_name"" dir=""auto"">Telegram</div>
  <i class=""link_preview_image"" style=""background-image:url('https://cdn4.telesco.pe/file/RwDORu9KHbEiyDuVv5c7LMdtqPcSKCu4x_mqpCOLP2HqKZG1Ddl6nJTYkBEY5vdT1zdpnBTjxXkge-nAQTWOrlaI0CLbzwRRIlV9qrDVXsaYMB-E0XIZATVMwlzuMxrojF-7IVw_CkIrKXVCs2apm5Kr7Jk3tAvN57xzqHYnPNKM5Eb0f_c2zLhVb3DXWywEN7iSR_hvhqgijoXzMoHEfFUxqfr9MtLVEp-HC5J4jkjq7_R0PSH53q_ShJ_iKf_V7Qzdggly2zuPsR-QzLWkvcRQGlEuZHSUbKyr4rUYvhUCMpiobCWI77t7QRvLB8HIxM6HwGmzgNr1DsUxw3h9xQ.jpg');width:66.625%;padding-top:100%""></i>
  <div class=""link_preview_title"" dir=""auto"">K1inUSA Multimedia</div>
  
</a>
<div class=""tgme_widget_message_footer"">
<div class=""tgme_widget_message_link"">
  <a href = ""https://t.me/K1inUSA/5341"" class=""link_anchor flex_ellipsis""><span class=""ellipsis"">t.me/K1inUSA</span>/5341</a>
</div>
<div class=""tgme_widget_message_info"">
  <span class=""tgme_widget_message_views"">9.7K</span><span class=""copyonly""> views</span><span class=""tgme_widget_message_meta""><span class=""tgme_widget_message_from_author"" dir=""auto"">کیوان ابراهیمی</span>,&nbsp;<a class=""tgme_widget_message_date"" href=""https://t.me/K1inUSA/5341""><time datetime = ""2018-03-13T06:03:16+00:00"" > Mar 13 at 06:03</time></a></span>
</div>
</div>
  </div>
</div>
    
    <script src = ""//telegram.org/js/widget-frame.js?17"" ></ script >
    < script > (function(i, s, o, g, r, a, m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function()
        {
            (i[r].q = i[r].q ||[]).push(arguments)},i[r].l=1*new Date(); a=s.createElement(o),
m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a, m)
    })(window, document,'script','//www.google-analytics.com/analytics.js','ga');

ga('create', 'UA-45099287-3', 'auto', { 'sampleRate': 5});
ga('send', 'pageview'); TWidgetPost.init('widget_message');
</script>
  </body>
</html>
<!-- page generated in 18.38ms -->
";
        #endregion

        #region Text with Photo

        internal const string TextWithPhotoPost =
@"<!DOCTYPE html>
<html>
  <head>
    <meta charset=""utf-8"">
    <title>Telegram Widget</title>
    <base target= ""_blank"" >
    < meta name= ""viewport"" content= ""width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"" />
    < meta name= ""format-detection"" content= ""telephone=no"" />
    < meta http-equiv= ""X-UA-Compatible"" content= ""IE=edge"" />
    < meta name= ""MobileOptimized"" content= ""176"" />
    < meta name= ""HandheldFriendly"" content= ""True"" />
    < meta name= ""robots"" content= ""noindex, nofollow"" />


    < link rel= ""shortcut icon"" href= ""//telegram.org/favicon.ico?3"" type= ""image/x-icon"" />
    < link href= ""https://fonts.googleapis.com/css?family=Roboto:400,500"" rel= ""stylesheet"" type= ""text/css"" >
    < link href= ""//telegram.org/css/widget-frame.css?9"" rel= ""stylesheet"" media= ""screen"" >
    < script > TBaseUrl = '//telegram.org/';</script>
  </head>
  <body class=""tgme_widget body_widget_post emoji_default"">
    <div class=""tgme_widget_message"" id=""widget_message"" data-view=""eyJ0IjoxNTIxMTM0NDQ2LCJoIjoiNzE0ZGU4MTBhZTA1NjE4OGU0In0"">
  <div class=""tgme_widget_message_user""><a href = ""https://t.me/K1inUSA"" >< i class=""tgme_widget_message_user_photo bgcolor4"" data-content=""K""><img src = ""https://cdn4.telesco.pe/file/CpZLfa51Dvi8iH8Qf-9X5X6Y1fZCt46Sugd6ri68JPF8VgR3cVJh4fUaCsVMyikQtkMdxVtHb-R2-ZCKQAolKejYsk1dXRDfnx9mtpbn5j1PNxuJ0P1n2Fx4XdgFY6rl2i8J0fDFJm6Li525DjbD8fXizh6RB1gRmL6ovdeAavCILZdP5q2m6Mp_HBzYm-PmjKcaN3ljTz4LF4CUiYLF8u3W77oPrkXz_pxmJiCjjYZ4I8cJ7vqlGAEFih5MGizlhzSY4cjBqPR0GKI43B4quREtvHLIfec-UDRhVLFMDrxDAN-Sn3lxeqCas_dwy0IunCLq6gdKPONSnsUCnA2kKw.jpg"" ></ i ></ a ></ div >
    
      < div class=""tgme_widget_message_bubble"">
    <i class=""tgme_widget_message_bubble_tail"">
      <svg width = ""9px"" height=""20px"" viewBox=""0 0 9 20"">
        <g fill = ""none"" >
          < path class=""background"" fill=""#fff"" d=""M1.29,0 L9,0 L9,20 L7,20 L7,17.411 C7,14.298 6.413 11.233 5.24 8.218 C4.336 5.893 2.794 3.733 0.614 1.738 L0.614 1.738 C0.207 1.365 0.179 0.732 0.552 0.325 C0.741 0.118 1.009 0 1.29 0 Z""/>
          <path class=""border"" stroke=""#d7e3ec"" stroke-width=""1"" d=""M9,0.5 L1.29,0.5 C1.149,0.5 1.015 0.559 0.921 0.662 C0.734,0.866 0.748 1.182 0.952 1.369 C3.186,3.414 4.772 5.637 5.706 8.036 C6.902,11.109 7.5 14.235 7.5 17.411 L7.5,20""/>
        </g>
      </svg>
    </i>
    <div class=""tgme_widget_message_author""><a class=""tgme_widget_message_owner_name"" href=""https://t.me/K1inUSA""><span dir = ""auto"" > K1 in USA</span></a></div>



<div class=""tgme_widget_message_text"" dir=""auto"">رئیس‌جمهور احمدی‌نژاد، وزیر اطلاعات را به سمت وزیر خارجه‌ی جمهوری اسلامی منصوب کرد&#33;<br/><br/>#کیوان_ابراهیمی<i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09FA493.png')""><b>🤓</b></i><i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87AEF09F87B7.png')""><b>🇮🇷</b></i><i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87BAF09F87B8.png')""><b>🇺🇸</b></i><br/><a href=""https://t.me/K1inUSAMultiMedia/60"" target=""_blank"" rel=""noopener"">https://t.me/K1inUSAMultiMedia/60</a><br/><br/>سطح جنجال این خبر را تصور کنید. حال خبر واقعی را بخوانید: رئیس‌جمهور دونالد ترامپ، رئیس سیا را به سمت وزیر خارجه‌ی ایالات متحده‌ی امریکا منصوب کرد. دلش خواست&#33; مگر جار و جنجال دارد؟<br/><br/>پی‌نوشت: پر واضح است که نام وزارت اطلاعات ایران و سازمان سیا نه به دلیل تشابه‌شان بلکه بنا به همتای یکدیگر بودن در دو کشور درج شده است...<br/><br/>پی‌نوشت ۲: جان برنان، رئیس سیا در دوره‌ی اوباما، از حسن روحانی حمایت کرده و نگرانی‌اش از انتخاب نشدنِ روحانی در انتخابات ایران را ابراز کرده بود. اما پمپئو پس از پیروزی ترامپ و تصدی ریاست سیا نوشته بود:<br/>«منتظرم برجام، این توافق فاجعه‌بار با بزرگترین دولت حامی تروریسم در جهان را بر هم بزنم&#33;» <a href=""http://t.me/K1inUSA/3515"" target=""_blank"" rel=""noopener"">t.me/K1inUSA/3515</a><br/><br/>پی‌نوشت ۳: دورانِ رقصِ تانگوی اوباما و روحانی (<a href=""http://t.me/K1inUSA/3609"" target=""_blank"" rel=""noopener"">t.me/K1inUSA/3609</a>) در آغوش هم تمام شده و دیگر از آن خبرها نیست. حال با انتخاب پمپئو باید بگوییم نعشِ برجام بای بای؟<br/><br/>مشاهدات و روزنوشته‌های دانشجویان و دانش‌آموختگان مسلمان ایرانی<i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87AEF09F87B7.png')""><b>🇮🇷</b></i> از امریکا<i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87BAF09F87B8.png')""><b>🇺🇸</b></i><br/><a href=""https://t.me/K1inUSA"" target=""_blank"">@K1inUSA</a></div>
<a class=""tgme_widget_message_link_preview"" href=""https://t.me/K1inUSAMultiMedia/60"">
  
  <div class=""link_preview_site_name"" dir=""auto"">Telegram</div>
  <i class=""link_preview_image"" style=""background-image:url('https://cdn4.telesco.pe/file/YD0mDezOdswFWB0jkACrOeffdkvOaRla4Fwe-jVqyMi4WTzl6dxGC8coIUZllsF7Wr5SEs82SNQTEslN7OJ7rUOJkLfk0aE6Qc7psLG0UEjuVi2L6M9LCgyX1lb8Jm5J6DYg5p5QEe1KaPLBR6j9bGt2_iRyLliPcFXdxnNop14HRI0m3EglYz44WZjq0RGfYc2mgiZ40T7lRlHGMskT0eoCbYFc9cfAPJx_gj1w0VUTjiHH_MdCLzodxMXzOJE4PukMkLVT4Sj4IxfdtCGUqdK0n_q9b77_7GujUwrAk2S5Omww4r9tDNdqPH7HqOtmNWSqZhjXH8dmRTzixHx7ZQ.jpg');padding-top:73.127753303965%""></i>
  <div class=""link_preview_title"" dir=""auto"">K1inUSA Multimedia</div>
  
</a>
<div class=""tgme_widget_message_footer"">
<div class=""tgme_widget_message_link"">
  <a href = ""https://t.me/K1inUSA/5343"" class=""link_anchor flex_ellipsis""><span class=""ellipsis"">t.me/K1inUSA</span>/5343</a>
</div>
<div class=""tgme_widget_message_info"">
  <span class=""tgme_widget_message_views"">11.0K</span><span class=""copyonly""> views</span><span class=""tgme_widget_message_meta""><span class=""tgme_widget_message_from_author"" dir=""auto"">کیوان ابراهیمی</span>,&nbsp; edited &nbsp;<a class=""tgme_widget_message_date"" href=""https://t.me/K1inUSA/5343""><time datetime = ""2018-03-13T12:55:55+00:00"" > Mar 13 at 12:55</time></a></span>
</div>
</div>
  </div>
</div>
    
    <script src = ""//telegram.org/js/widget-frame.js?17"" ></ script >
    < script > (function(i, s, o, g, r, a, m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function()
        {
            (i[r].q = i[r].q ||[]).push(arguments)},i[r].l=1*new Date(); a=s.createElement(o),
m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a, m)
    })(window, document,'script','//www.google-analytics.com/analytics.js','ga');

ga('create', 'UA-45099287-3', 'auto', { 'sampleRate': 5});
ga('send', 'pageview'); TWidgetPost.init('widget_message');
</script>
  </body>
</html>
<!-- page generated in 16.97ms -->
";

        #endregion

        #region Photo with Text

        internal const string PhotoWithText =
@"<!DOCTYPE html>
<html>
  <head>
    <meta charset=""utf-8"">
    <title>Telegram Widget</title>
    <base target= ""_blank"" >
    < meta name= ""viewport"" content= ""width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"" />
    < meta name= ""format-detection"" content= ""telephone=no"" />
    < meta http-equiv= ""X-UA-Compatible"" content= ""IE=edge"" />
    < meta name= ""MobileOptimized"" content= ""176"" />
    < meta name= ""HandheldFriendly"" content= ""True"" />
    < meta name= ""robots"" content= ""noindex, nofollow"" />


    < link rel= ""shortcut icon"" href= ""//telegram.org/favicon.ico?3"" type= ""image/x-icon"" />
    < link href= ""https://fonts.googleapis.com/css?family=Roboto:400,500"" rel= ""stylesheet"" type= ""text/css"" >
    < link href= ""//telegram.org/css/widget-frame.css?9"" rel= ""stylesheet"" media= ""screen"" >
    < script > TBaseUrl = '//telegram.org/';</script>
  </head>
  <body class=""tgme_widget body_widget_post emoji_default"">
    <div class=""tgme_widget_message"" id=""widget_message"" data-view=""eyJ0IjoxNTIxMTQxOTIxLCJoIjoiY2QxYzU5ZGE0ZDg5ODlhMzIyIn0"">
  <div class=""tgme_widget_message_user""><a href = ""https://t.me/K1inUSA"" >< i class=""tgme_widget_message_user_photo bgcolor4"" data-content=""K""><img src = ""https://cdn4.telesco.pe/file/CpZLfa51Dvi8iH8Qf-9X5X6Y1fZCt46Sugd6ri68JPF8VgR3cVJh4fUaCsVMyikQtkMdxVtHb-R2-ZCKQAolKejYsk1dXRDfnx9mtpbn5j1PNxuJ0P1n2Fx4XdgFY6rl2i8J0fDFJm6Li525DjbD8fXizh6RB1gRmL6ovdeAavCILZdP5q2m6Mp_HBzYm-PmjKcaN3ljTz4LF4CUiYLF8u3W77oPrkXz_pxmJiCjjYZ4I8cJ7vqlGAEFih5MGizlhzSY4cjBqPR0GKI43B4quREtvHLIfec-UDRhVLFMDrxDAN-Sn3lxeqCas_dwy0IunCLq6gdKPONSnsUCnA2kKw.jpg"" ></ i ></ a ></ div >
    
      < div class=""tgme_widget_message_bubble"">
    <i class=""tgme_widget_message_bubble_tail"">
      <svg width = ""9px"" height=""20px"" viewBox=""0 0 9 20"">
        <g fill = ""none"" >
          < path class=""background"" fill=""#fff"" d=""M1.29,0 L9,0 L9,20 L7,20 L7,17.411 C7,14.298 6.413 11.233 5.24 8.218 C4.336 5.893 2.794 3.733 0.614 1.738 L0.614 1.738 C0.207 1.365 0.179 0.732 0.552 0.325 C0.741 0.118 1.009 0 1.29 0 Z""/>
          <path class=""border"" stroke=""#d7e3ec"" stroke-width=""1"" d=""M9,0.5 L1.29,0.5 C1.149,0.5 1.015 0.559 0.921 0.662 C0.734,0.866 0.748 1.182 0.952 1.369 C3.186,3.414 4.772 5.637 5.706 8.036 C6.902,11.109 7.5 14.235 7.5 17.411 L7.5,20""/>
        </g>
      </svg>
    </i>
    <div class=""tgme_widget_message_author""><a class=""tgme_widget_message_owner_name"" href=""https://t.me/K1inUSA""><span dir = ""auto"" > K1 in USA</span></a></div>
<div class=""tgme_widget_message_forwarded_from"">Forwarded from&nbsp;<a class=""tgme_widget_message_forwarded_from_name"" href=""https://t.me/RouhaniThesis/500"" dir=""auto"">Rouhani Thesis<i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F939A.png')""><b>📚</b></i><i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F948E.png')""><b>🔎</b></i></a></div>

<a class=""tgme_widget_message_photo_wrap"" href=""https://t.me/K1inUSA/5346"" style=""background-image:url('https://cdn4.telesco.pe/file/YdIJjbNhXgITU56L0kIKAA584M5f216ueXs4QgbKKSSDhVEh2OSKW0ak-Sq_NfgqFxRUvQI6mubBdnd65VXUup1P17tPrC8LmXn4Z9NEOMjDjgN5D4Qdmv4eycFEJf9HvMTwTtODzi-hk5TF2d540HO1mosc_HHwvRa2CEjQnx3rxzvihG5MerWQXotfUFJY6I5VnZIEQNtE1YUv0ASMq2p6FIS050Uki-VkjY0gRIvYHEDxTjPfc9Zm3nDtUnwLlfNYjUh2M8wkPA6Y4khldyYYXRQHyInAKttuFWvQ19slGj_KGAogQX2rbJUv67oHC_TRI0mUlt3Ky9z9zzN87A.jpg')"">
  <div class=""tgme_widget_message_photo"" style=""padding-top:87.561374795417%""></div>
</a>
<div class=""tgme_widget_message_text"" dir=""auto"">رسوایی تحصیلی روحانی به Study International رسید:<br/>«سیاستمداران و اتهامات سرقت علمی آکادمیک علیه آنان»<br/><br/>آیا یک دکترا برای مشتی پستِ سیاسی ارزشش را داشت که اینگونه کشور را بی‌آبرو کند؟<br/><a href = ""https://t.me/RouhaniThesis"" target=""_blank"">@RouhaniThesis</a> <i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F939A.png')""><b>📚</b></i><i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F948E.png')""><b>🔎</b></i></div>

<div class=""tgme_widget_message_footer"">
<div class=""tgme_widget_message_link"">
  <a href = ""https://t.me/K1inUSA/5346"" class=""link_anchor flex_ellipsis""><span class=""ellipsis"">t.me/K1inUSA</span>/5346</a>
</div>
<div class=""tgme_widget_message_info"">
  <span class=""tgme_widget_message_views"">11.5K</span><span class=""copyonly""> views</span><span class=""tgme_widget_message_meta""><span class=""tgme_widget_message_from_author"" dir=""auto"">کیوان ابراهیمی</span>,&nbsp;<a class=""tgme_widget_message_date"" href=""https://t.me/K1inUSA/5346""><time datetime = ""2018-03-14T09:17:19+00:00"" > Mar 14 at 09:17</time></a></span>
</div>
</div>
  </div>
</div>
    
    <script src = ""//telegram.org/js/widget-frame.js?17"" ></ script >
    < script > (function(i, s, o, g, r, a, m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function()
        {
            (i[r].q = i[r].q ||[]).push(arguments)},i[r].l=1*new Date(); a=s.createElement(o),
m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a, m)
    })(window, document,'script','//www.google-analytics.com/analytics.js','ga');

ga('create', 'UA-45099287-3', 'auto', { 'sampleRate': 5});
ga('send', 'pageview'); TWidgetPost.init('widget_message');
</script>
  </body>
</html>
<!-- page generated in 13.67ms -->
";

        #endregion

        #region Direct Video Post

        internal const string DirectVideoPost =
@"<!DOCTYPE html>
<html>
  <head>
    <meta charset=""utf-8"">
    <title>Telegram Widget</title>
    <base target= ""_blank"" >
    < meta name= ""viewport"" content= ""width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"" />
    < meta name= ""format-detection"" content= ""telephone=no"" />
    < meta http-equiv= ""X-UA-Compatible"" content= ""IE=edge"" />
    < meta name= ""MobileOptimized"" content= ""176"" />
    < meta name= ""HandheldFriendly"" content= ""True"" />
    < meta name= ""robots"" content= ""noindex, nofollow"" />


    < link rel= ""shortcut icon"" href= ""//telegram.org/favicon.ico?3"" type= ""image/x-icon"" />
    < link href= ""https://fonts.googleapis.com/css?family=Roboto:400,500"" rel= ""stylesheet"" type= ""text/css"" >
    < link href= ""//telegram.org/css/widget-frame.css?9"" rel= ""stylesheet"" media= ""screen"" >
    < script > TBaseUrl = '//telegram.org/';</script>
  </head>
  <body class=""tgme_widget body_widget_post emoji_default"">
    <div class=""tgme_widget_message"" id=""widget_message"" data-view=""eyJ0IjoxNTIxMTI2MTcwLCJoIjoiMjBmYmJhMTdiMmNkMjRlMGU4In0"">
  <div class=""tgme_widget_message_user""><a href = ""https://t.me/K1inUSA"" >< i class=""tgme_widget_message_user_photo bgcolor4"" data-content=""K""><img src = ""https://cdn4.telesco.pe/file/CpZLfa51Dvi8iH8Qf-9X5X6Y1fZCt46Sugd6ri68JPF8VgR3cVJh4fUaCsVMyikQtkMdxVtHb-R2-ZCKQAolKejYsk1dXRDfnx9mtpbn5j1PNxuJ0P1n2Fx4XdgFY6rl2i8J0fDFJm6Li525DjbD8fXizh6RB1gRmL6ovdeAavCILZdP5q2m6Mp_HBzYm-PmjKcaN3ljTz4LF4CUiYLF8u3W77oPrkXz_pxmJiCjjYZ4I8cJ7vqlGAEFih5MGizlhzSY4cjBqPR0GKI43B4quREtvHLIfec-UDRhVLFMDrxDAN-Sn3lxeqCas_dwy0IunCLq6gdKPONSnsUCnA2kKw.jpg"" ></ i ></ a ></ div >
    
      < div class=""tgme_widget_message_bubble"">
    <i class=""tgme_widget_message_bubble_tail"">
      <svg width = ""9px"" height=""20px"" viewBox=""0 0 9 20"">
        <g fill = ""none"" >
          < path class=""background"" fill=""#fff"" d=""M1.29,0 L9,0 L9,20 L7,20 L7,17.411 C7,14.298 6.413 11.233 5.24 8.218 C4.336 5.893 2.794 3.733 0.614 1.738 L0.614 1.738 C0.207 1.365 0.179 0.732 0.552 0.325 C0.741 0.118 1.009 0 1.29 0 Z""/>
          <path class=""border"" stroke=""#d7e3ec"" stroke-width=""1"" d=""M9,0.5 L1.29,0.5 C1.149,0.5 1.015 0.559 0.921 0.662 C0.734,0.866 0.748 1.182 0.952 1.369 C3.186,3.414 4.772 5.637 5.706 8.036 C6.902,11.109 7.5 14.235 7.5 17.411 L7.5,20""/>
        </g>
      </svg>
    </i>
    <div class=""tgme_widget_message_author""><a class=""tgme_widget_message_owner_name"" href=""https://t.me/K1inUSA""><span dir = ""auto"" > K1 in USA</span></a></div>


<a class=""tgme_widget_message_video_player"" id=""message_video_player"" href=""https://t.me/K1inUSA/5345""><i class=""tgme_widget_message_video_thumb"" style=""background-image:url('https://cdn4.telesco.pe/file/NRZNGD67Ux3AqTkNBVutVdl5_zj_96VUKJnbSwwPPUcaTZmigornklVjBrV7P6ozQMWjqRXW_bF47VuVRe1gxM4aOW8OM5J9PJCTGGCKr2e4hXrLZANZ7gWYdaHSlEORZXS_3hQZAwiYbpqSJQrI4xYeBZ6J83N4delDgUrShDadzp8TTIqBucSJrwYmnTIhfCkGsdWLVbM8IaCdBGpM7Hvfx3crhpi716DWtykWNGtROnpbeKkksPPsB1329vWq-In5LLgQyLD19_HUs-Ya888pGFkJSpAXPFJIeYLWPAi0m12o_BZzVSKu0_7035_RqMqdDz1EzKx9kK0F6BH_vQ')""></i>

<div class=""tgme_widget_message_video_wrap"" style=""padding-top:56.25%"">
  <video src = ""https://cdn4.telesco.pe/file/JLCJyK-X9Q4pIX_-eyYEZDsMx8Skouq7xJblmyriqtkMBBKbt31fUGf074q90aOfM42YZ5NHYJ5FLlf0Jukm8K2x1olin1PygvDPYMutyhytmTMOk3jC7F8OECjW810eLc28-0KWg627KlaQSKxsLdJkTUcNTInrfeuKsdxbLUDzGIqWRk0FNvueZvMvRrImYu-s4p8Q46_nntxVbSgTx1282UMPY3A-hwtRW8b4FSMNOzVN9reGK8-bqP3RAT0TSu_kALz0UTPPCGKksPd6nuiu9RPgPibF1M0AR-Z-c0FYmZf11GR3ALHPXTuqCwS6F2ciXgRnrQibRjxiitw7Kg.mp4"" class=""tgme_widget_message_video"" id=""message_video"" width=""100%"" height=""100%""></video>
</div>
<div class=""message_video_play"" id=""message_video_play""></div>
<time class=""message_video_duration"" id=""message_video_duration"">2:50</time>
<div class=""message_media_not_supported_wrap"" id=""message_video_not_supported"">
  <div class=""message_media_not_supported"">
    <div class=""message_media_not_supported_label"">This media is not supported in your browser</div>
    <span class=""message_media_view_in_telegram"">VIEW IN TELEGRAM</span>
  </div>
</div></a>
<div class=""tgme_widget_message_text"" dir=""auto""><i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F93BD.png')""><b>📽</b></i> خلاصه‌ی تصویریِ فصل آخرِ داستانِ «مزرعه‌ی حیوانات» اثر جورج اوروِل<br/> متن یادداشت «مزرعه‌ی حیوانات و انقلابِ ما»: <a href = ""https://t.me/K1inUSA/5344"" target=""_blank"" rel=""noopener"">https://t.me/K1inUSA/5344</a><br/><a href=""https://t.me/K1inUSA"" target=""_blank"">@K1inUSA</a> <i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87AEF09F87B7.png')""><b>🇮🇷</b></i><i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87BAF09F87B8.png')""><b>🇺🇸</b></i></div>

<div class=""tgme_widget_message_footer"">
<div class=""tgme_widget_message_link"">
  <a href = ""https://t.me/K1inUSA/5345"" class=""link_anchor flex_ellipsis""><span class=""ellipsis"">t.me/K1inUSA</span>/5345</a>
</div>
<div class=""tgme_widget_message_info"">
  <span class=""tgme_widget_message_views"">6.0K</span><span class=""copyonly""> views</span><span class=""tgme_widget_message_meta""><span class=""tgme_widget_message_from_author"" dir=""auto"">کیوان ابراهیمی</span>,&nbsp; edited &nbsp;<a class=""tgme_widget_message_date"" href=""https://t.me/K1inUSA/5345""><time datetime = ""2018-03-14T05:49:10+00:00"" > Mar 14 at 05:49</time></a></span>
</div>
</div>
  </div>
</div>
    
    <script src = ""//telegram.org/js/widget-frame.js?17"" ></ script >
    < script > (function(i, s, o, g, r, a, m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function()
        {
            (i[r].q = i[r].q ||[]).push(arguments)},i[r].l=1*new Date(); a=s.createElement(o),
m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a, m)
    })(window, document,'script','//www.google-analytics.com/analytics.js','ga');

ga('create', 'UA-45099287-3', 'auto', { 'sampleRate': 5});
ga('send', 'pageview'); TVideo.init('message_video');
TWidgetPost.init('widget_message');
</script>
  </body>
</html>
<!-- page generated in 13.33ms -->
";
        #endregion

        #region Linked Video Post

        internal const string LinkedVideoPost =
@"<!DOCTYPE html>
<html>
  <head>
    <meta charset=""utf-8"">
    <title>Telegram Widget</title>
    <base target= ""_blank"" >
    < meta name= ""viewport"" content= ""width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"" />
    < meta name= ""format-detection"" content= ""telephone=no"" />
    < meta http-equiv= ""X-UA-Compatible"" content= ""IE=edge"" />
    < meta name= ""MobileOptimized"" content= ""176"" />
    < meta name= ""HandheldFriendly"" content= ""True"" />
    < meta name= ""robots"" content= ""noindex, nofollow"" />


    < link rel= ""shortcut icon"" href= ""//telegram.org/favicon.ico?3"" type= ""image/x-icon"" />
    < link href= ""https://fonts.googleapis.com/css?family=Roboto:400,500"" rel= ""stylesheet"" type= ""text/css"" >
    < link href= ""//telegram.org/css/widget-frame.css?9"" rel= ""stylesheet"" media= ""screen"" >
    < script > TBaseUrl = '//telegram.org/';</script>
  </head>
  <body class=""tgme_widget body_widget_post emoji_default"">
    <div class=""tgme_widget_message"" id=""widget_message"" data-view=""eyJ0IjoxNTIxMTI2Mzg3LCJoIjoiZWVlYzYwNjRiOTJlMjAxMjQ4In0"">
  <div class=""tgme_widget_message_user""><a href = ""https://t.me/K1inUSA"" >< i class=""tgme_widget_message_user_photo bgcolor4"" data-content=""K""><img src = ""https://cdn4.telesco.pe/file/CpZLfa51Dvi8iH8Qf-9X5X6Y1fZCt46Sugd6ri68JPF8VgR3cVJh4fUaCsVMyikQtkMdxVtHb-R2-ZCKQAolKejYsk1dXRDfnx9mtpbn5j1PNxuJ0P1n2Fx4XdgFY6rl2i8J0fDFJm6Li525DjbD8fXizh6RB1gRmL6ovdeAavCILZdP5q2m6Mp_HBzYm-PmjKcaN3ljTz4LF4CUiYLF8u3W77oPrkXz_pxmJiCjjYZ4I8cJ7vqlGAEFih5MGizlhzSY4cjBqPR0GKI43B4quREtvHLIfec-UDRhVLFMDrxDAN-Sn3lxeqCas_dwy0IunCLq6gdKPONSnsUCnA2kKw.jpg"" ></ i ></ a ></ div >
    
      < div class=""tgme_widget_message_bubble"">
    <i class=""tgme_widget_message_bubble_tail"">
      <svg width = ""9px"" height=""20px"" viewBox=""0 0 9 20"">
        <g fill = ""none"" >
          < path class=""background"" fill=""#fff"" d=""M1.29,0 L9,0 L9,20 L7,20 L7,17.411 C7,14.298 6.413 11.233 5.24 8.218 C4.336 5.893 2.794 3.733 0.614 1.738 L0.614 1.738 C0.207 1.365 0.179 0.732 0.552 0.325 C0.741 0.118 1.009 0 1.29 0 Z""/>
          <path class=""border"" stroke=""#d7e3ec"" stroke-width=""1"" d=""M9,0.5 L1.29,0.5 C1.149,0.5 1.015 0.559 0.921 0.662 C0.734,0.866 0.748 1.182 0.952 1.369 C3.186,3.414 4.772 5.637 5.706 8.036 C6.902,11.109 7.5 14.235 7.5 17.411 L7.5,20""/>
        </g>
      </svg>
    </i>
    <div class=""tgme_widget_message_author""><a class=""tgme_widget_message_owner_name"" href=""https://t.me/K1inUSA""><span dir = ""auto"" > K1 in USA</span></a></div>



<div class=""tgme_widget_message_text"" dir=""auto"">ربات‌های خود مختار و وفق‌پذیر<br/><br/>#کیوان_ابراهیمی<i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09FA493.png')""><b>🤓</b></i><i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87AEF09F87B7.png')""><b>🇮🇷</b></i><i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87BAF09F87B8.png')""><b>🇺🇸</b></i><br/><a href=""https://t.me/K1inUSAMultiMedia/31"" target=""_blank"" rel=""noopener"">https://t.me/K1inUSAMultiMedia/31</a><br/><br/>بوستون داینامیکس ربات‌هایی می‌سازد که انسان را متحیر می‌کند. بسیاری از این ربات‌ها توسط دارپا تأمین بودجه می‌شوند و کاربردهای محتمل نظامی دارند. آخرین نمونه‌ی ساخت این کمپانی می‌تواند درب‌های ساختمان را باز کرده و به دوست خود اجازه‌ی ورود دهد. به فیلم پیوست و ریزِ رفتارهای خودمختار (autonomous) این دو ربات دقت کنید.<br/><br/>نکته‌ی مهم در این ربات‌ها، قابلیت سازگاری و وفق‌پذیری یا adaptability است. یعنی ربات برای هر شرایطی می‌تواند تصمیم بگیرد و موفق شود. اینطور نیست که از پیش، فقط برای باز کردن یک درب خاص طراحی شده باشد و نتواند بقیه‌ی درب‌ها را باز کند.<br/><br/>این شرکت ربات‌ها را به اشکال مختلف از جمله انسان‌نما می‌سازد اما به سگ علاقه‌ی خاصی دارد. نمونه‌ی قدیمی و به یاد ماندنیِ «سگ بزرگ» که به شکل عجیبی می‌تواند روی زمین یخ‌زده و پس از برخورد ضربه و لگد، تعادل خود را حفظ کند، اینجا قابل مشاهده است:<br/><a href=""https://t.me/K1inUSAMultiMedia/30"" target=""_blank"" rel=""noopener"">https://t.me/K1inUSAMultiMedia/30</a><br/><br/>مشاهدات و روزنوشته‌های دانشجویان و دانش‌آموختگان مسلمان ایرانی<i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87AEF09F87B7.png')""><b>🇮🇷</b></i> از امریکا<i class=""emoji"" style=""background-image:url('//telegram.org/img/emoji/40/F09F87BAF09F87B8.png')""><b>🇺🇸</b></i><br/><a href=""https://t.me/K1inUSA"" target=""_blank"">@K1inUSA</a><br/>به ما بپیوندید: <a href=""https://t.me/joinchat/AAAAADwnejmuoSjHfYDniw"" target=""_blank"" rel=""noopener"">https://t.me/joinchat/AAAAADwnejmuoSjHfYDniw</a></div>
<a class=""tgme_widget_message_link_preview"" href=""https://t.me/K1inUSAMultiMedia/31"">
  
  <div class=""link_preview_site_name"" dir=""auto"">Telegram</div>
  <div class=""link_preview_video_player"" id=""message_video_player"" style="""">
  <i class=""link_preview_video_thumb"" style=""background-image:url('https://cdn4.telesco.pe/file/cTE4gcRcWwDSWaH7AZaG8R6pGKoq15LXbp8a4CyKDVhyVV7jpJFRXMzWZn1JB5Gi3i8lU92ZN5ZYsoSLcuQZs_2_QfFRsalR9A61WxLfaUIsszPfi21V1BZB04WcrBP1T3sQPkfd2qLS_W8rh-9yMb9X5P0WDxkUhab6V_T2IJ4pmJfPTHz10DhiblW-Boik8jR-5R6853cl8ucA8H5i7nITrCPBeyxhTbHqvOvfm5DdpGMyJkTUK1MCw-ACC6aoiiFFMHCcQouJS6S35dLHpBMI1l7ihBHNijZJhFp70LDxwD8fUGSq3weF5PHz6gajS2KOHkzftYEddbK6ZDiQQg')""></i>
  <div class=""link_preview_video_wrap"" style=""padding-top:56.25%"">
    <video class=""link_preview_video"" id=""message_video"" src=""https://cdn4.telesco.pe/file/v-cnRq1EX3x4nJ0JgTCHbQ5NGBuUS9Gn4f94qQ8lwPFqmNfafLIiiST8FOmXDdQ-mhqKaoTSTe2AR0BnPE2M8ac_Ft1rPP6hv2tELHXAxQ4UDSBJ56nacsLo0Hr250Jbw-GKEQWoLr_NKmFHbyTF6zQNf3s3biV1wlGAXrn8pbNSFTnyXLlsg5LHsKbkc8okU5jJPWpCPspRWLCykxk_BV1zXjZj6wO48WMNmg3eGTstukOo4Srf4zshoE16AKZ6uoiJbtY9u0wrYx_n1197oMsZapsetAmIBxp4lN7mTZLL1zI-h5tzgLYGZDN1bqTfQkzZLs_5NM-sPeMjBAi25A.mp4"" width=""100%"" height=""100%""></video>
  </div>
  <div class=""message_video_play"" id=""message_video_play""></div>
<time class=""message_video_duration"" id=""message_video_duration"">0:44</time>
</div>
  <div class=""link_preview_title"" dir=""auto"">K1inUSA Multimedia</div>
  
</a>
<div class=""tgme_widget_message_footer"">
<div class=""tgme_widget_message_link"">
  <a href = ""https://t.me/K1inUSA/5309"" class=""link_anchor flex_ellipsis""><span class=""ellipsis"">t.me/K1inUSA</span>/5309</a>
</div>
<div class=""tgme_widget_message_info"">
  <span class=""tgme_widget_message_views"">11.4K</span><span class=""copyonly""> views</span><span class=""tgme_widget_message_meta""><span class=""tgme_widget_message_from_author"" dir=""auto"">کیوان ابراهیمی</span>,&nbsp; edited &nbsp;<a class=""tgme_widget_message_date"" href=""https://t.me/K1inUSA/5309""><time datetime = ""2018-02-18T15:46:25+00:00"" > Feb 18 at 15:46</time></a></span>
</div>
</div>
  </div>
</div>
    
    <script src = ""//telegram.org/js/widget-frame.js?17"" ></ script >
    < script > (function(i, s, o, g, r, a, m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function()
        {
            (i[r].q = i[r].q ||[]).push(arguments)},i[r].l=1*new Date(); a=s.createElement(o),
m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a, m)
    })(window, document,'script','//www.google-analytics.com/analytics.js','ga');

ga('create', 'UA-45099287-3', 'auto', { 'sampleRate': 5});
ga('send', 'pageview'); TVideo.init('message_video');
TWidgetPost.init('widget_message');
</script>
  </body>
</html>
<!-- page generated in 17.67ms -->
";
        #endregion
    }
}
