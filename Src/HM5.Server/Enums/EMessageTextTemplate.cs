namespace HM5.Server.Enums
{
    public enum EMessageTextTemplate
    {
        None = 0,
        /// A string that is the same in all translations of the game. Can be used to craft any message with TemplateData.
        Silverballer = -1915785609,
        /// {userid}  challenge you|||{userid}  bet {amount} that you cannot complete this {contractid} in {number}  tries or less	
        Text1 = -908540459,
        /// {userid}  accept challenge|||{userid}  have accepted your Face-Off on {contractid} and paid {amount} to the pool	
        Text2 = 1355912303,
        /// {userid}  chicken out|||{userid} chicken out of your Face-Off on {contractid}, and returned your {amount} bet	
        Text3 = 668378361,
        /// {userid} completed your challenge|||{userid} completed your Face-Off on {contractid}, took your money and left	
        Text4 = -1179504294,
        /// {userid} failed your challenge|||{userid} tried hard but failed on your Face-Off on {contractid} and transferred {amount} to your account	
        Text5 = -826998324,
        /// {userid} like your contract|||{userid} played your Face-Off your contract {contractid} and liked it.	
        Text6 = 1471959158,
        /// {userid} ignored your Face-Off|||You challenged {userid} on {contractid}. It was ignored, and expired. Your {amount} bet has been transferred back to your account	
        Text7 = 549150944,
        /// {userid} re-challenge you|||{userid} humiliated you on {contractid}, upped the stakes and re-challenge you to beat his score in {number} tries or less	
        Text8 = -1341883023,
        /// Challenge expires in 24 hours|||{userid} bet {amount} that you cannot complete {contractid} in {number} tries or less. You only have 24 hours left before it expires.	
        Text9 = -956084761,
        /// Achievement unlocked|||You have challenged other players with 10 Face-Off. As a bonus {amount} have been transferred to your account. Keep up the good work.	
        Text10 = -1480276990,
        /// who is the best assassin|||{userid} have challenged {userid} with a Face-Off  on your contract {contractid}. Chip in to show them who is the best assassin	
        Text11 = -792464236,
        /// {userid} found the hidden contract|||{userid} found a hidden contract on this level. Find the contract and play it  from contracts mode	
        Text12 = 1238017326,
        /// 34% found the hidden contract|||[34%] of all players have found the hidden The Path of Hitman contract on this level. Find the contract and play it  from contracts mode	
        Text13 = 1053660600,
        /// 34% completed as Silent Assassin|||[34%] of all players completed {CheckPoint} as Silent Assassin not leaving a single trace behind	
        Text14 = -1599537125,
        /// {userid} is Silent Assassin|||{userid} completed {CheckPoint} as Silent Assassin not leaving a single trace behind	
        Text15 = -676450163,
        /// {userid} is Perfect shooter||| {userid} completed {CheckPoint} with Perfect shooter, without wasting a single bullet	
        Text16 = 1319592247,
        /// Almost …Silent Assassin …|||You are … (this far) from completing as Silent Assassin …	
        Text17 = 966807969,
        /// create your own contracts|||You can also create your own contracts …	
        Text18 = -1457566672,
        /// First Created contract|||Well done on your first created contract. You can send your contract to a friend as a challenge him to see who is the best assassin	
        Text19 = -568820570,
        /// {userid} reached {CheckPoint} |||{userid} has reached [level]. Your {contractid} takes place in that location. Challenge him with this contract	
        Text20 = -1930848319,
        /// 10 created contract|||Congratulations on your first 10 created contract. {amount} Keep up the good work	
        Text21 = -68245673,
        /// Players like your  {contractid} |||Players like your  {contractid}  you should challenge a friend with this to see who is the best assassin	
        Text22 = 1659369197,
        /// Competition Opportunity|||You have created a number of Contracts, but have yet to challenge any of your friends to compete with you. You should create a Competition and send it your friends!	
        Text23 = 367052411,
        /// {userid}  reached {CheckPoint}|||{userid}  has reached {CheckPoint} . Your {contractid} takes place in that location. Challenge him with this contract	
        Text24 = -1954262056,
        /// {userid} LIKED A CONTRACT YOU CREATED|||Your friend {userid} played your contract codenamed {contractid}  and liked it. Take the opportunity to create a Competition with {userid}, and see who is the best assassin!	
        Text25 = -58498226,
        /// Achievement unlocked|||You have created 2 unique contracts. {amount}	
        Text26 = 1703555828,
        /// Achievement unlocked|||Your contracts are becoming more popular; more than 10 different players have now played your contracts.	
        Text27 = 311231074,
        /// 50 played your contracts|||Your contracts are very popular; more than 50 different players have now played your contracts. Seems like you are good at creating interesting contracts	
        Text28 = -2110644237,
        /// {userid} beat your score.|||{userid} have played your {contractid}  and beat your score by {amount}. You should challenge him with a Face-Off to claim back the high score rights	
        Text29 = -181063835,
        /// 25 like your contracts|||25 players have completed and liked a contract you created. Seems like you are good at creating interesting contracts	
        Text30 = -1779259776,
        /// {userid} cannot complete your {contractid}|||{userid} played your {contractid}  several times without completing. Challenge him with a Face-Off  in this to see who is the best assassin	
        Text31 = -487221738,
        /// {userid} liked your {contractid}|||{userid} have played your {contractid}  and liked it. Select to send him a Face-Off	
        Text32 = 2080163756,
        /// {userid} challenged {userid} on your {contractid} .|||{userid} have challenged {userid} on {contractid} . Challenge them with a Face-Off to see who is the best assassin	
        Text33 = 217839418,
        /// You stole the ownership from [userid]|||You stole the ownership from {userid} and set a new high score with {amount}	
        Text34 = -1835048295,
        /// {userid} beat your high score|||{userid} the new owner  beat your high score and set a new high score with {amount} – and  telling you to fuck off	
        Text35 = -443002353,
        /// Join this week's competition|||Show your assassin's skills. Join this week's competition on {contractid}  and  {4} other contracts	
        Text36 = 2089878453,
        /// Join this week's competition|||Show your assassin's skills. Join this week's competition on {contractid}  and {4} other contracts	
        Text37 = 194392867,
        /// {userid} signed up|||{userid} signed up for this week's competition.  Show you assassin's skills. Join this week's competition on {contractid}  and {4} other contracts	
        Text38 = -1691799886,
        /// {userid} is ahead of you|||{userid} is ahead of you in this week's competition . Step up and improve your score on {contractid}	
        Text39 = -332521948,
        /// {userid} is behind you|||{userid} is behind you in this week's competition - keep up the good work	
        Text40 = -625790905,
        /// Your current {leaderboardposition}|||We are half way through this week's competition. Your total score is {amount} which reach for  a current {leaderboardposition} on the Ranked leaderboard	
        Text41 = -1380712239,
        /// You ended as {leaderboardposition}|||This week's competition has ended. Your total score was {amount} which send up to a {leaderboardposition} on the Ranked leaderboard	
        Text42 = 884822379,
        /// You ended 2nd amongst friends|||This week's competition has ended. Your total score was {amount} which 2nd best compared to your friends. Behind {userid} but in front of [gamertag]	
        Text43 = 1136288253,
        /// you clearly beat [gamertag]|||Good work, you clearly beat {userid} in this week's competition, and he knows	
        Text44 = -572591010,
        /// {userid} clearly beat you|||{userid} clearly beat you in this week's competition and he knows	
        Text45 = -1428568888,
        /// Achievement unlocked|||You have created 10 unique contracts. {amount} . Keep up the good work and try your luck in the competitions	
        Text46 = 869307762,
        /// Join this week's competition|||Get back and show your assassin's skills. Join this week's competition on {contractid} and {4} other contracts	
        Text47 = 1154983396,
        /// Join this week's competition|||Get back and show your assassin's skills. Join this week's competition on {contractid} and {4} other contracts	
        Text48 = -731334539,
        /// Join this week's competition|||It's been {4} weeks since you show your assassin's skills. Join this week's competition on {contractid} and {4} other contracts. {amount}  A as gift the first try is free	
        Text49 = -1552971549,
        /// {userid} is this winner this week|||The winner this week 1-10 big earner of the week reward {amount}	
        Text50 = -1012399866,
        /// the world's best players|||This week we have a Face-Off between the world's best players - follow the competition on www.barcodesociety.com	
        Text51 = -1263586928,
        /// {userid} is in the lead of the world's best players|||{userid} is in the lead of the Face-Off between the world's best players –follow the competition on www.barcodesociety.com	
        Text52 = 765878314,
        /// {userid} is the world's best players|||{userid} won the Face-Off between the world's best players –follow the competition on www.barcodesociety.com	
        Text53 = 1520521404,
        /// Join the Barcode Society|||Join the Barcode Society on www.barcodesociety.com and follow your progress, join the community and be the first to get all the Hitman news	
        Text54 = -993671905,
        /// Download Hitman Laptop|||Download Hitman Laptop for your phone and follow your progress, join the community and be the first to get all the Hitman news (scan the barcode from the extras menu with your phone to download the Laptop – link to the menu)	
        Text55 = -1279068791,
        /// Join the Barcode Society|||Join the Barcode Society on www.barcodesociety.com and sign up for the weekly competition – and follow your progress - from anywhere	
        Text56 = 717988915,
        /// Download Hitman Laptop|||Download Hitman Laptop for your phone and sign up for the weekly ranked competition – and follow your progress, send contracts, challenge friends and customize weapons  - from anywhere	
        Text57 = 1573688485,
        /// follow {userid} progress on your Face-Off|||Download Hitman Laptop for your phone and follow {userid} progress on your Face-Off on {contractid}  - from anywhere.	
        Text58 = -848066252,
        /// Join Barcode Society|||Join Barcode Society on www.barcodesociety.com or download Hitman Laptop for your phone and vote for which contracts goes into next week's Ranked competition	
        Text59 = -1166755422,
        /// Define your assassin identity|||Define your gamer identity – complete your profile	
        Text60 = -393915707,
        /// Welcome back|||Welcome back – your sniper challenge high score was … {amount}  use it wisely in contracts mode + sniper/upgrades unlocked	
        Text61 = -1618845101,
        /// Create contracts|||Create contracts – other can play and see if they can solve your puzzle	
        Text62 = 109786089,
        /// Unlock contracts|||Play story mode and unlock contracts – challenge fried's to do better than you	
        Text63 = 1905001343,
        /// Unlock stuff|||Play story mode to unlock stuff you can use when creating new contracts	
        Text64 = -269969700,
        /// Best assassin|||Play other players created contract and see who the best assassin is …	
        Text65 = -1729124790,
        /// Play other players created contract|||Play other players created contract and see who the best assassin is …	
        Text66 = 31913968,
        /// Status report on accomplishments|||Status: There are 47 achievements and xx ratings – you have 5% of them	
        Text67 = 1994508134,
        /// Status report on challenges |||Status: There are xx challenges  – you have 5% of them	
        Text68 = -429991177,
        /// Find a challenge here|||You missed some challenges: Try out this…	
        Text69 = -1856378271,
        /// Status report on weapons |||Status: There are xx weapons  – you have 5% of them	
        Text70 = -241278076,
        /// Status report on techniques|||Status: There are xx techniques and xx upgrades  – you have 1 of them	
        Text71 = -2036772078,
        /// Status report on disguises|||Status: There are xx disguises – you have 5% of them	
        Text72 = 529531560,
        /// Status report on accomplishments|||Status: There are 47 achievements and xx ratings – you have 47% of them	
        Text73 = 1754739262,
        /// Status report on challenges |||Status: There are xx challenges  – you have 47% of them	
        Text74 = -151804003,
        /// Find a challenge here|||You missed some challenges: Try out this…	
        Text75 = -2114676981,
        /// Status report on|||Status: There are xx weapons  – you have 47% of them	
        Text76 = 419284657,
        /// Status report on techniques|||Status: There are xx techniques and xx upgrades  – you have 5 of them	
        Text77 = 1878717991,
        /// Status report on disguises|||Status: There are xx disguises – you have 47% of them	
        Text78 = -12194890,
        /// Status report on accomplishments|||Status: you have all xx achievement and rating	
        Text79 = -2008884448,
        /// Status report on challenges |||Status: you have all xx challenges	
        Text80 = 1980137291,
        /// Status report on weapons |||Status: you have all weapons	
        Text81 = 16863197,
        /// Status report on techniques|||Status: you have all techniques	
        Text82 = -1744298393,
        /// Status report on disguises|||Status: you have all disguises	
        Text83 = -284217615,
        /// {userid} completed  …|||{userid}  completed 47% of all challenges	
        Text84 = 1902885714,
        /// {userid} unlocked …|||{userid} unlocked 47% of all  disguises	
        Text85 = 107776964,
        /// {userid} unlocked …|||{userid} unlocked 47% of all techniques	
        Text86 = -1620714882,
        /// {userid} unlocked …|||{userid} unlocked 47% of all weapons	
        Text87 = -396170520,
        /// {userid} completed  …|||{userid}  completed all challenges	
        Text88 = 2027812729,
        /// {userid} unlocked …|||{userid} unlocked all  disguises	
        Text89 = 265996271,
        /// {userid} unlocked …|||{userid} unlocked all techniques	
        Text90 = 1864191498,
        /// {userid} unlocked …|||{userid} unlocked all weapons	
        Text91 = 404389532,
        /// New contract unlocked|||You have unlocked the Path of Hitman. Start your first contract from contracts mode, and start your journey towards the world's best assassin {amount}	
        Text92 = -2129449178,
        /// Achievement unlocked|||You have started your path to become a Hitman – your first The Path of Hitman contract in a series of contracts. Now find the others and complete The Path of Hitman. {amount}	
        Text93 = -166453328,
        /// 2 contracts unlocked|||You have 2 new unlocked The Path of Hitman contracts.  Start them from contracts mode, and start your journey towards the world's best assassin in The Path of Hitman	
        Text94 = 1752205843,
        /// 5 contracts unlocked|||You have 5 unlocked contracts.  Start them from contracts mode, and challenge your friends to be the best assassin	
        Text95 = 527940229,
        /// Achievement unlocked|||Well done man … {amount}	
        Text96 = -2038502593,
        /// Achievement unlocked|||Well done man … {amount}	
        Text97 = -243672151,
        /// Achievement unlocked|||Well done man… {amount}	
        Text98 = 1640416824,
        /// The world's wealthiest agency|||The world's wealthiest agency this week is {agency}	
        Text99 = 381810350,
        /// The world's most clandestine agency|||The world's most clandestine agency this week is {agency}	
        Text100 = -1088577676,
        /// create your own agency|||Join an agency or create your own agency at Barcode Society at www.barcode_society.com	
        Text101 = -937775134,
        /// {userid}  is now a member of {agency} |||{userid}  is now a member of {agency} . Join at Barcode Society at www.barcode_society.com	
        Text102 = 1360264792,
        /// Your agency {agency}   beat {agency}|||Your agency {agency}   beat {agency} by {amount} in this week's ranked competition.	
        Text103 = 638897870,
        /// Face-Off between the world's best agencies|||This week we have a Face-Off between the world's two best agencies; {agency}  and   {agency}  - follow the competition on www.barcode_society.com	
        Text104 = -1200596115,
        /// {agency}  is in the lead |||{agency}  is in the lead of the Face-Off between the world's best agencies – follow the competition on www.barcode_society.com	
        Text105 = -814257157,
        /// {agency}  won the Face-Off|||{agency}  won the Face-Off between the world's best agencies – follow the competition on www.barcode_society.com	
        Text106 = 1451113025,
        /// Try {ChallengeOnThisCheckpoint}|||Try completing {ChallengeOnThisCheckpoint} on this checkpoint!	
        Text107 = 561580759,
        /// UserId scored UserIdsScore|||UserId's score is: UserIdsScore. See if you can do better!	
        Text108 = -1312417978,
        /// NEW COMPETITION LEADER: {LeaderName}|||Competition Leaderboard Update. {LeaderName} set a new high score of {LeaderScore} for this competition, and is now the Competition Leader.	
        Text109 = -960419888,
        /// {userid} RECOMMENDED A CONTRACT|||Your friend {userid} played a contract codenamed {contractid} and liked it.  Give it a try!	
        Text110 = -1509511627,
        /// CONTRACT LIKE RECEIVED|||Your contract codenamed {contractname} has received a like, and been recommended for replay. Well done!	
        Text111 = 1208536857,
        /// {userid} COMPLETED YOUR CONTRACT|||{userid} completed your contract codenamed {ContractName} with a score of {score}	
        Text112 = -1586795988,
        /// {userid} PLAYED THE SAME CONTRACT AS YOU|||Your friend {userid} scored {score } on a contract that you've also played. The contract codenamed {ContractName}.	
        Text113 = -697541958,
        /// {userid} BEAT YOUR SCORE|||Your friend {userid} has beaten your score on the contract codenamed {contractname} and set a new high score of {score}.	
        Text114 = 1332022016,
        /// {userid} BEAT YOUR SCORE|||Your friend {userid} has beaten your score on {CheckPointName} and set a new high score of {score}.	
        Text115 = -788423005,
        /// COMPETITION COMPLETE|||The competition is now closed. The overall winner was {WinnerName}, with a high score of {WinnerScore}. Thank you for competing! No further scores will be accepted for the competition.
        Text116 = 892486188,
        /// CONTRACT SELECTED FOR COMPETITION|||Your contract codenamed "{ContractName}" has been selected for use in a Contract Competition by {CompetitionCreatorName}. Make sure to check out the leaderboards to see the progress as the competition unfolds!
        Text117 = 262240066,
        /// {CompetitionCreatorName} INVITED YOU TO A COMPETITION|||You have been challenged to a Contract Competition! {CompetitionCreatorName} has challenged you to prove your skills on the contract codenamed "{ContractName}"! Good luck!
        Text118 = -1442004174,
        /// YOU WON THE COMPETITON! |||Your high score of {PlayerScore} won the Contract Competition created by {CompetitionCreatorName}. Well done!
        Text119 = 170131594,
        /// COMPETITION COMPLETE|||{NumberOfParticipants} players participated in a Competition created by {CompetitionCreatorName} on one of your contracts. The winning score of {WinnerScore} was achieved by {WinnerName}. Well done for creating an awesome contract!
        Text120 = 133618571,
        /// COMPETITION COMPLETE|||{NumberOfParticipants} players participated in the competition you created. The highest score of {WinnerScore} achieved was by {WinnerName}. Well done for creating an awesome Competition!
        Text121 = -1541873685,
        /// COMPETITION COMPLETE|||The competition is now closed. Your score was {PlayerScore}, and this earned {TrophiesEarned} Competition Medals for your participation. The overall winner was {WinnerName}, with a high score of {WinnerScore}. Thank you for competing!
        Text122 = -1340520181
    }
}