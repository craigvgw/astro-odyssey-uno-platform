﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using System.Linq;

namespace AstroOdyssey
{
    public class LocalizationHelper : ILocalizationHelper
    {
        #region Fields

        private readonly LocalizationKey[] LOCALIZATION_KEYS = new LocalizationKey[]
        {
            #region Game Start Page

		    new LocalizationKey(key: "ApplicationName_Header", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Astro Odyssey"),
                new ("bn", "অ্যাস্ট্রো ওডিসি"),
            }),
            new LocalizationKey(key: "GameStartPage_Tagline", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "A classic rock metal ⚡ space shooter on WebAssembly."),
                new ("bn", "WebAssembly-এ একটি ক্লাসিক রক মেটাল ⚡ স্পেস শ্যুটার।"),
            }),

            new LocalizationKey(key: "GameStartPage_BanglaButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Bangla"),
                new ("bn", "বাংলা"),
            }),
            new LocalizationKey(key: "GameStartPage_DeutschButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Deutsch"),
                new ("bn", "ডয়েচ"),
            }),
            new LocalizationKey(key: "GameStartPage_EnglishButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "English"),
                new ("bn", "ইংরেজি"),
            }),
            new LocalizationKey(key: "GameStartPage_FrenchButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "French"),
                new ("bn", "ফরাসি"),
            }),

            new LocalizationKey(key: "GameStartPage_PlayButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Start Game"),
                new ("bn", "খেলা শুরু করুন"),
            }),

            new LocalizationKey(key: "GameStartPage_LogoutButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Logout"),
                new ("bn", "প্রস্থান"),
            }),

            new LocalizationKey(key: "GameStartPage_BrandProfileButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Made with ❤️ by Asadullah Rifat"),
                new ("bn", "আসাদুল্লাহ রিফাত দ্বারা ❤️ দিয়ে তৈরি"),
            }),

            new LocalizationKey(key: "GameStartPage_WelcomeBackText", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "👋 Welcome Back!"),
                new ("bn", "👋 স্বাগতম!"),
            }),

            new LocalizationKey(key: "LOADING_GAME_ASSETS", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Loading game assets..."),
                new ("bn", "গেমের সম্পদ লোড হচ্ছে ..."),
            }),

            new LocalizationKey(key: "GameStartPage_CookieText", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "We use cookies to provide the best gaming experience!"),
                new ("bn", "আমরা সেরা গেমিংয়ের অভিজ্ঞতা সরবরাহ করতে কুকি ব্যবহার করি!"),                
            }),
            new LocalizationKey(key: "GameStartPage_CookieDeclineButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "👎"),
                new ("bn", "👎"),
            }),
            new LocalizationKey(key: "GameStartPage_CookieAcceptButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "👍"),
                new ("bn", "👍"),
            }),
	        #endregion

            #region Ship Selection Page            

		    new LocalizationKey(key: "Antimony", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Antimony"),
                new ("bn", "অ্যান্টিমনি"),
            }),
            new LocalizationKey(key: "Bismuth", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Bismuth"),
                new ("bn", "বিসমাথ"),
            }),
            new LocalizationKey(key: "Curium", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Curium"),
                new ("bn", "কিউরিয়াম"),
            }),

            new LocalizationKey(key: "ShipSelectionPage_Header", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Welcome to"),
                new ("bn", "স্বাগতম"),
            }),

            new LocalizationKey(key: "ShipSelectionPage_Tagline", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Choose a spaceship"),
                new ("bn", "একটি স্পেসশিপ চয়ন করুন"),
            }),

            new LocalizationKey(key: "ShipSelectionPage_ControlInstructions", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Each spaceship offers a different gaming experience."),
                new ("bn", "প্রতিটি স্পেসশিপ একটি আলাদা গেমিং অভিজ্ঞতা সরবরাহ করে।"),
            }),

            new LocalizationKey(key: "ShipSelectionPage_ChooseButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Select"),
                new ("bn", "নির্বাচন করুন"),
            }),

	        #endregion

            #region Game Instructions Page

            new LocalizationKey(key: "GameInstructionsPage_Tagline", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "How To Play"),
                new ("bn", "কিভাবে খেলতে হবে"),
            }),

            new LocalizationKey(key: "GameInstructionsPage_ControlsText", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Controls"),
                new ("bn", "নিয়ন্ত্রণ"),
            }),
            new LocalizationKey(key: "GameInstructionsPage_ControlsText2", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Move to ⬅️ or ➡️ with the arrow keys on your ⌨️ or use the touch screen of your 📱."),
                new ("bn", "আপনার ⌨ এ তীর কীগুলি দিয়ে ⬅ বা ➡ এ যান বা আপনার 📱 এর টাচ স্ক্রিনটি ব্যবহার করুন।"),
            }),

            new LocalizationKey(key: "GameInstructionsPage_EnemiesText", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Enemies & Meteors"),
                new ("bn", "শত্রু ও উল্কা"),
            }),
            new LocalizationKey(key: "GameInstructionsPage_EnemiesText2", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Shoot them and avoid collision."),
                new ("bn", "তাদের গুলি করুন এবং সংঘর্ষ এড়িয়ে চলুন।"),
            }),

            new LocalizationKey(key: "GameInstructionsPage_BossesText", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Bosses"),
                new ("bn", "বস"),
            }),
            new LocalizationKey(key: "GameInstructionsPage_BossesText2", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Defeat them to get to the next level."),
                new ("bn", "পরবর্তী স্তরে পৌঁছানোর জন্য তাদের পরাজিত করুন।"),
            }),

            new LocalizationKey(key: "GameInstructionsPage_HealthText", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Healths"),
                new ("bn", "স্বাস্থ্য"),
            }),
            new LocalizationKey(key: "GameInstructionsPage_HealthText2", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Collect them to repair your spaceship."),
                new ("bn", "আপনার স্পেসশিপটি মেরামত করতে এগুলি সংগ্রহ করুন।"),
            }),

            new LocalizationKey(key: "GameInstructionsPage_PowerupText", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Power-ups"),
                new ("bn", "শক্তি বৃদ্ধি"),
            }),
            new LocalizationKey(key: "GameInstructionsPage_PowerupText2", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Collect them to get more powerful weapons."),
                new ("bn", "আরও শক্তিশালী অস্ত্র পেতে তাদের সংগ্রহ করুন।"),
            }),

            new LocalizationKey(key: "GameInstructionsPage_CollectiblesText", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Collectibles"),
                new ("bn", "সংগ্রহযোগ্য"),
            }),
            new LocalizationKey(key: "GameInstructionsPage_CollectiblesText2", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Collect them to increase your firepower and activate 2x score."),
                new ("bn", "আপনার ফায়ারপাওয়ার বাড়াতে এবং 2x স্কোর সক্রিয় করতে এগুলি সংগ্রহ করুন।"),
            }),

            new LocalizationKey(key: "GameInstructionsPage_PlayButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "👍 Okay"),
                new ("bn", "👍 ঠিক আছে"),
            }),

	        #endregion

            #region Game Play Page

		    new LocalizationKey(key: "BEAM_CANNON", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "BEAM CANNON"),
                new ("bn", "রশ্মি কামান"),
            }),
            new LocalizationKey(key: "BLAZE_BLITZ", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "BLAZE BLITZ"),
                new ("bn", "ব্লেজ ব্লিটজ"),
            }),
            new LocalizationKey(key: "PLASMA_BOMB", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "PLASMA BOMB"),
                new ("bn", "প্লাজমা বোমা"),
            }),

            new LocalizationKey(key: "BOSS", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "BOSS"),
                new ("bn", "বস"),
            }),
            new LocalizationKey(key: "CLOAK_DOWN", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "CLOAK DOWN"),
                new ("bn", "ক্লোক ডাউন"),
            }),
            new LocalizationKey(key: "CLOAK_UP", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "CLOAK UP"),
                new ("bn", "ক্লোক আপ"),
            }),
            new LocalizationKey(key: "FIRING_RATE_DECREASED", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "FIRING RATE DECREASED"),
                new ("bn", "গুলিবর্ষণের হার কমেছে"),
            }),
            new LocalizationKey(key: "FIRING_RATE_INCREASED", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "FIRING RATE INCREASED"),
                new ("bn", "গুলিবর্ষণের হার বেড়েছে"),
            }),
            new LocalizationKey(key: "SHIELD_DOWN", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "SHIELD DOWN"),
                new ("bn", "শিল্ড ডাউন"),
            }),
            new LocalizationKey(key: "SHIELD_UP", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "SHIELD UP"),
                new ("bn", "শিল্ড আপ"),
            }),

            new LocalizationKey(key: "COMPLETE", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "COMPLETE"),
                new ("bn", "সম্পূর্ণ"),
            }),
            new LocalizationKey(key: "ENEMY_APPROACHES", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "ENEMY APPROACHES"),
                new ("bn", "শত্রু কাছে পৌঁছেছে"),
            }),
            new LocalizationKey(key: "FANTASTIC_GAME", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Fantastic game"),
                new ("bn", "চমত্কার খেলা"),
            }),
            new LocalizationKey(key: "GAME_PAUSED", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "GAME PAUSED"),
                new ("bn", "খেলা থামানো হয়েছে"),
            }),
            new LocalizationKey(key: "GOOD_GAME", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Good game"),
                new ("bn", "ভাল খেলা"),
            }),
            new LocalizationKey(key: "GREAT_GAME", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Great game"),
                new ("bn", "অসাধারন খেলা"),
            }),
            new LocalizationKey(key: "LEVEL", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "LEVEL"),
                new ("bn", "স্তর"),
            }),
            new LocalizationKey(key: "NO_LUCK", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "No luck"),
                new ("bn", "দুর্ভাগ্য"),
            }),
            new LocalizationKey(key: "POWER_DOWN", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "POWER DOWN"),
                new ("bn", "ক্ষমতা হ্রাস"),
            }),
            new LocalizationKey(key: "QUIT_GAME", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "QUIT GAME?"),
                new ("bn", "খেলা বন্ধ?"),
            }),
            new LocalizationKey(key: "SCORE", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Score"),
                new ("bn", "স্কোর"),
            }),
            new LocalizationKey(key: "YOUR_SCORE", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Your Score"),
                new ("bn", "আপনার ফলাফল"),
            }),
            new LocalizationKey(key: "PERSONAL_BEST_SCORE", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "🤘 Personal Best Score"),
                new ("bn", "🤘 ব্যক্তিগত সেরা স্কোর"),
            }),
            new LocalizationKey(key: "LAST_GAME_SCORE", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "🕹️ Last Game Score"),
                new ("bn", "🕹️ শেষ গেম স্কোর"),
            }),

            new LocalizationKey(key: "DESTROYED", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Destroyed"),
                new ("bn", "ধ্বংস"),
            }),
            new LocalizationKey(key: "ENEMIES_DESTROYED", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Enemies"),
                new ("bn", "শত্রু"),
            }),
            new LocalizationKey(key: "METEORS_DESTROYED", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Meteors"),
                new ("bn", "উল্কা"),
            }),
            new LocalizationKey(key: "BOSSES_DESTROYED", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Bosses"),
                new ("bn", "বস"),
            }),
            new LocalizationKey(key: "COLLECTIBLES_COLLECTED", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Collectibles"),
                new ("bn", "সংগ্রহযোগ্য"),
            }),

            new LocalizationKey(key: "SHIP_REPAIRED", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "SHIP REPAIRED"),
                new ("bn", "জাহাজ মেরামত"),
            }),

            new LocalizationKey(key: "SONIC_BLAST", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "SONIC BLAST"),
                new ("bn", "সোনিক বিস্ফোরণ"),
            }),
            new LocalizationKey(key: "SUPREME_GAME", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Supreme game"),
                new ("bn", "সর্বোচ্চ খেলা"),
            }),
            new LocalizationKey(key: "TAP_ON_SCREEN_TO_BEGIN", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "TAP ON THE SCREEN TO BEGIN"),
                new ("bn", "শুরু করতে স্ক্রিনে ট্যাপ করুন"),
            }),
            new LocalizationKey(key: "TAP_TO_QUIT", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "TAP TO QUIT"),
                new ("bn", "প্রস্থান করতে ট্যাপ করুন"),
            }),
            new LocalizationKey(key: "TAP_TO_RESUME", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "TAP TO RESUME"),
                new ("bn", "আবার শুরু করতে ট্যাপ করুন"),
            }),

            new LocalizationKey(key: "SCORE_MULTIPLIER_ON", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "2x SCORE ON"),
                new ("bn", "2x স্কোর চালু"),
            }),
            new LocalizationKey(key: "SCORE_MULTIPLIER_OFF", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "COLLECT MORE GUITARS"),
                new ("bn", "আরও গিটার সংগ্রহ করুন"),
            }),

	        #endregion

            #region Game Over Page

            new LocalizationKey(key: "GameOverPage_SignupPromptText", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "You could earn your place on the leaderboard if you login."),
                new ("bn", "লগইন করলে আপনি লিডারবোর্ডে আপনার জায়গা অর্জন করতে পারেন।"),
            }),

            new LocalizationKey(key: "GameOverPage_Tagline", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Game Over"),
                new ("bn", "খেলা শেষ"),
            }),

            new LocalizationKey(key: "GameOverPage_PlayAgainButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Play Again"),
                new ("bn", "আবার খেলুন"),
            }),

            new LocalizationKey(key: "GameOverPage_LeaderboardButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Leaderboard"),
                new ("bn", "লিডারবোর্ড"),
            }),

	        #endregion

            #region Game Login Page

            new LocalizationKey(key: "GameLoginPage_UserNameBox", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Username or Email"),
                new ("bn", "ব্যবহারকারী নাম বা ইমেল"),
            }),

            new LocalizationKey(key: "GameLoginPage_PasswordBox", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Password"),
                new ("bn", "পাসওয়ার্ড"),
            }),

            new LocalizationKey(key: "GameLoginPage_LoginButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Login"),
                new ("bn", "প্রবেশ করুন"),
            }),

            new LocalizationKey(key: "GameLoginPage_RegisterButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "No account yet?"),
                new ("bn", "এখনও কোন অ্যাকাউন্ট নেই?"),
            }),

        	#endregion

            #region Game Signup Page

            new LocalizationKey(key: "GameSignupPage_UserFullNameBox", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Enter full name"),
                new ("bn", "পুরো নাম লিখুন"),
            }),

            new LocalizationKey(key: "GameSignupPage_UserEmailBox", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Enter email"),
                new ("bn", "ইমেইল প্রদান করুন"),
            }),

            new LocalizationKey(key: "GameSignupPage_UserNameBox", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Set a username"),
                new ("bn", "একটি ব্যবহারকারীর নাম সেট করুন"),
            }),

            new LocalizationKey(key: "GameSignupPage_PasswordBox", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Set a password"),
                new ("bn", "একটি পাসওয়ার্ড সেট করুন"),
            }),

            new LocalizationKey(key: "GameSignupPage_ConfirmPasswordBox", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Confirm password"),
                new ("bn", "পাসওয়ার্ড নিশ্চিত করুন"),
            }),

            new LocalizationKey(key: "GameSignupPage_SignupButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Signup"),
                new ("bn", "নিবন্ধন করুন"),
            }),

            new LocalizationKey(key: "GameSignupPage_LoginButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "You already have an account?"),
                new ("bn", "আপনার ইতিমধ্যেই একটি অ্যাকাউন্ট আছে?"),
            }),

            new LocalizationKey(key: "GameSignupPage_ConfirmCheckBox", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Yes, I agree to the conditions of participation."),
                new ("bn", "হ্যাঁ, আমি অংশগ্রহণের শর্তে সম্মত।"),
            }),

            new LocalizationKey(key: "PASSWORDS_DIDNT_MATCH", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Passwords didn't match"),
                new ("bn", "পাসওয়ার্ড মেলে না"),
            }),

            new LocalizationKey(key: "PASSWORDS_MATCHED", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Passwords matched"),
                new ("bn", "পাসওয়ার্ড মিলেছে"),
            }),

            new LocalizationKey(key: "LENGTH_MUST_BE_GREATER_THAN_8_CHARS", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Password must be at least eight characters"),
                new ("bn", "পাসওয়ার্ড অবশ্যই কমপক্ষে আটটি অক্ষর হতে হবে"),
            }),

            new LocalizationKey(key: "LENGTH_MUST_BE_LESS_THAN_14_CHARS", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Password must be less than fourteen characters"),
                new ("bn", "পাসওয়ার্ড অবশ্যই চৌদ্দ অক্ষরের চেয়ে কম হতে হবে"),
            }),

            new LocalizationKey(key: "MUST_CONTAIN_ONE_UPPERCASE_CHAR", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Password must contain one uppercase character"),
                new ("bn", "পাসওয়ার্ডে অবশ্যই একটি বড় হাতের অক্ষর থাকতে হবে"),
            }),

            new LocalizationKey(key: "MUST_CONTAIN_ONE_LOWERCASE_CHAR", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Password must contain one lowercase character"),
                new ("bn", "পাসওয়ার্ডে অবশ্যই একটি ছোট হাতের অক্ষর থাকতে হবে"),
            }),

            new LocalizationKey(key: "MUST_NOT_CONTAIN_SPACE", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Password cannot contain spaces"),
                new ("bn", "পাসওয়ার্ডে স্পেস থাকতে পারবে না"),
            }),

            new LocalizationKey(key: "MUST_CONTAIN_ONE_SPECIAL_CHAR", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Password must contain one special character"),
                new ("bn", "পাসওয়ার্ডে অবশ্যই একটি বিশেষ অক্ষর থাকতে হবে"),
            }),

            new LocalizationKey(key: "PASSWORD_IS_STRONG", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Password is strong"),
                new ("bn", "পাসওয়ার্ড শক্তিশালী"),
            }),

            new LocalizationKey(key: "INVALID_CHARACTERS_IN_FULLNAME", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Invalid characters in full name"),
                new ("bn", "পুরো নামে অবৈধ অক্ষর"),
            }),

	        #endregion

            #region Game Leaderboard Page

            new LocalizationKey(key: "GameLeaderboardPage_Tagline", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Leaderboard"),
                new ("bn", "লিডারবোর্ড"),
            }),

            new LocalizationKey(key: "GameLeaderboardPage_DailyScoreboardToggle", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "📅 Daily"),
                new ("bn", "📅 দৈনিক"),
            }),

            new LocalizationKey(key: "GameLeaderboardPage_AllTimeScoreboardToggle", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "👑 All time"),
                new ("bn", "👑 সর্বকালে"),
            }),

            new LocalizationKey(key: "GameLeaderboardPage_PlayNowButton", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Play now"),
                new ("bn", "এখনই খেলুন"),
            }),

            new LocalizationKey(key: "LOADING_DATA", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "Loading data..."),
                new ("bn", "তথ্য প্রস্তুত হচ্ছে..."),
            }),
            new LocalizationKey(key: "NO_DATA_AVAILABLE", cultureValues: new (string Culture, string Value)[]
            {
                new ("en", "No data available."),
                new ("bn", "কোন তথ্য নেই।"),
            }),

	        #endregion
        };

        #endregion

        #region Methods
        /// <summary>
        /// Gets the localization resource.
        /// </summary>
        /// <param name="resourceKey"></param>
        /// <returns></returns>
        public string GetLocalizedResource(string resourceKey)
        {
            var localizationTemplate = LOCALIZATION_KEYS.FirstOrDefault(x => x.Key == resourceKey);
            return localizationTemplate?.CultureValues.FirstOrDefault(x => x.Culture == App.CurrentCulture).Value;
        }

        /// <summary>
        /// Sets a localized value on the provided ui element.
        /// </summary>
        /// <param name="uIElement"></param>
        public void SetLocalizedResource(UIElement uIElement)
        {
            var localizationTemplate = LOCALIZATION_KEYS.FirstOrDefault(x => x.Key == uIElement.Name);

            if (localizationTemplate is not null)
            {
                var value = localizationTemplate?.CultureValues.FirstOrDefault(x => x.Culture == App.CurrentCulture).Value;

                if (uIElement is TextBlock textBlock)
                    textBlock.Text = value;
                else if (uIElement is TextBox textBox)
                    textBox.Header = value;
                else if (uIElement is PasswordBox passwordBox)
                    passwordBox.Header = value;
                else if (uIElement is Button button)
                    button.Content = value;
                else if (uIElement is ToggleButton toggleButton)
                    toggleButton.Content = value;
                else if (uIElement is HyperlinkButton hyperlinkButton)
                    hyperlinkButton.Content = value;
                else if (uIElement is CheckBox checkBox)
                    checkBox.Content = value;
            }
        }

        #endregion        
    }
}
