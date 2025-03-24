TelegramGateWay Test Project - ushbu loyiha TelegramGateway SDK dan foydalanish orqali Telegram orqali xabar yuborish funksiyalarini test qilish uchun yaratilgan. Loyiha quyidagi ikki usulda konfiguratsiya qilinishi mumkin:

1. To'liq konfiguratsiya (AccessToken va BaseUrl kiritilgan)
Agar siz API uchun AccessToken bilan bir qatorda BaseUrl ham qo‘lda belgilamoqchi bo‘lsangiz, quyidagi tarzda sozlang:

    builder.Services.AddTelegramGateWay(options =>
    {
        // Telegram Gateway API uchun access token (konfiguratsiya orqali olinadi)
        options.AccessToken = builder.Configuration["TelegramGateWay:AccessToken"];
        
        // API ning bazaviy URL manzili (ixtiyoriy, kiritilmasa ham bo‘laveradi)
        options.BaseUrl = "https://gatewayapi.telegram.org/";
    });

Ushbu usulda siz to‘liq sozlash parametrlarini uzatasiz va kerakli qiymatlar aniqlanadi.

2. Minimal konfiguratsiya (Faqat AccessToken)
Agar faqat AccessToken ni taqdim etishni xohlasangiz, quyidagi usuldan foydalanishingiz mumkin:

    builder.Services.AddTelegramGateWay(
        builder.Configuration["TelegramGateWay:AccessToken"] 
        ?? throw new Exception("Token is required")
    );

Bu holatda, faqat token yetkaziladi va qolgan sozlamalar (masalan, BaseUrl) default qiymat sifatida qo‘llaniladi.


Qo‘shimcha Eslatmalar

    DI konfiguratsiyasi:
Har ikkala usulda ham, SDK ning kerakli qismlari (Telegram.GateWay.Abstractions va Telegram.GateWay.Api) DI (Dependency Injection) orqali loyihaga qo‘shiladi.

    AccessToken majburiy:
AccessToken kiritilmagan holatda loyiha ishga tushmaydi. Shu sababli, agar token topilmasa, 2-usulda Exception chiqariladi.

    Optional parametrlar:
Agar BaseUrl ni kiritmasangiz, SDK default qiymat (masalan, "https://gatewayapi.telegram.org/") bilan ishlashi mumkin.

Ushbu konfiguratsiya misollari orqali siz SDK dan TelegramGateWayTest loyihasida samarali foydalanishingiz va Telegram API orqali xabar yuborishni test qilishingiz mumkin.