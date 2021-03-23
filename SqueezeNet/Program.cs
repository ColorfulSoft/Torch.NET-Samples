﻿// (C) ColorfulSoft corp., 2021. All Rights reserved.
using System;
using System.AI;
using System.Linq;
using System.Collections.Generic;

using models = System.AI.torchvision.models;

namespace Test
{

    public static class Program
    {

        public static torch.Tensor load(string uri)
        {
            return torch.tensor(imageio.imread(uri)).transpose(0, 2).transpose(1, 2).unsqueeze(0).@float() / 255f;
        }

        #region imagenet_classes
        public static string[] imagenet_classes = new string[]
        {
            "tench, Tincatinca",
            "goldfish, Carassiusauratus",
            "greatwhiteshark, whiteshark, man-eater, man-eatingshark, Carcharodoncarcharias",
            "tigershark, Galeocerdocuvieri",
            "hammerhead, hammerheadshark",
            "electricray, crampfish, numbfish, torpedo",
            "stingray",
            "cock",
            "hen",
            "ostrich, Struthiocamelus",
            "brambling, Fringillamontifringilla",
            "goldfinch, Cardueliscarduelis",
            "housefinch, linnet, Carpodacusmexicanus",
            "junco, snowbird",
            "indigobunting, indigofinch, indigobird, Passerinacyanea",
            "robin, Americanrobin, Turdusmigratorius",
            "bulbul",
            "jay",
            "magpie",
            "chickadee",
            "waterouzel, dipper",
            "kite",
            "baldeagle, Americaneagle, Haliaeetusleucocephalus",
            "vulture",
            "greatgreyowl, greatgrayowl, Strixnebulosa",
            "Europeanfiresalamander, Salamandrasalamandra",
            "commonnewt, Triturusvulgaris",
            "eft",
            "spottedsalamander, Ambystomamaculatum",
            "axolotl, mudpuppy, Ambystomamexicanum",
            "bullfrog, Ranacatesbeiana",
            "treefrog, tree-frog",
            "tailedfrog, belltoad, ribbedtoad, tailedtoad, Ascaphustrui",
            "loggerhead, loggerheadturtle, Carettacaretta",
            "leatherbackturtle, leatherback, leatheryturtle, Dermochelyscoriacea",
            "mudturtle",
            "terrapin",
            "boxturtle, boxtortoise",
            "bandedgecko",
            "commoniguana, iguana, Iguanaiguana",
            "Americanchameleon, anole, Anoliscarolinensis",
            "whiptail, whiptaillizard",
            "agama",
            "frilledlizard, Chlamydosauruskingi",
            "alligatorlizard",
            "Gilamonster, Helodermasuspectum",
            "greenlizard, Lacertaviridis",
            "Africanchameleon, Chamaeleochamaeleon",
            "Komododragon, Komodolizard, dragonlizard, giantlizard, Varanuskomodoensis",
            "Africancrocodile, Nilecrocodile, Crocodylusniloticus",
            "Americanalligator, Alligatormississipiensis",
            "triceratops",
            "thundersnake, wormsnake, Carphophisamoenus",
            "ringnecksnake, ring-neckedsnake, ringsnake",
            "hognosesnake, puffadder, sandviper",
            "greensnake, grasssnake",
            "kingsnake, kingsnake",
            "gartersnake, grasssnake",
            "watersnake",
            "vinesnake",
            "nightsnake, Hypsiglenatorquata",
            "boaconstrictor, Constrictorconstrictor",
            "rockpython, rocksnake, Pythonsebae",
            "Indiancobra, Najanaja",
            "greenmamba",
            "seasnake",
            "hornedviper, cerastes, sandviper, hornedasp, Cerastescornutus",
            "diamondback, diamondbackrattlesnake, Crotalusadamanteus",
            "sidewinder, hornedrattlesnake, Crotaluscerastes",
            "trilobite",
            "harvestman, daddylonglegs, Phalangiumopilio",
            "scorpion",
            "blackandgoldgardenspider, Argiopeaurantia",
            "barnspider, Araneuscavaticus",
            "gardenspider, Araneadiademata",
            "blackwidow, Latrodectusmactans",
            "tarantula",
            "wolfspider, huntingspider",
            "tick",
            "centipede",
            "blackgrouse",
            "ptarmigan",
            "ruffedgrouse, partridge, Bonasaumbellus",
            "prairiechicken, prairiegrouse, prairiefowl",
            "peacock",
            "quail",
            "partridge",
            "Africangrey, Africangray, Psittacuserithacus",
            "macaw",
            "sulphur-crestedcockatoo, Kakatoegalerita, Cacatuagalerita",
            "lorikeet",
            "coucal",
            "beeeater",
            "hornbill",
            "hummingbird",
            "jacamar",
            "toucan",
            "drake",
            "red-breastedmerganser, Mergusserrator",
            "goose",
            "blackswan, Cygnusatratus",
            "tusker",
            "echidna, spinyanteater, anteater",
            "platypus, duckbill, duckbilledplatypus, duck-billedplatypus, Ornithorhynchusanatinus",
            "wallaby, brushkangaroo",
            "koala, koalabear, kangaroobear, nativebear, Phascolarctoscinereus",
            "wombat",
            "jellyfish",
            "seaanemone, anemone",
            "braincoral",
            "flatworm, platyhelminth",
            "nematode, nematodeworm, roundworm",
            "conch",
            "snail",
            "slug",
            "seaslug, nudibranch",
            "chiton, coat-of-mailshell, seacradle, polyplacophore",
            "chamberednautilus, pearlynautilus, nautilus",
            "Dungenesscrab, Cancermagister",
            "rockcrab, Cancerirroratus",
            "fiddlercrab",
            "kingcrab, Alaskacrab, Alaskankingcrab, Alaskakingcrab, Paralithodescamtschatica",
            "Americanlobster, Northernlobster, Mainelobster, Homarusamericanus",
            "spinylobster, langouste, rocklobster, crawfish, crayfish, seacrawfish",
            "crayfish, crawfish, crawdad, crawdaddy",
            "hermitcrab",
            "isopod",
            "whitestork, Ciconiaciconia",
            "blackstork, Ciconianigra",
            "spoonbill",
            "flamingo",
            "littleblueheron, Egrettacaerulea",
            "Americanegret, greatwhiteheron, Egrettaalbus",
            "bittern",
            "crane",
            "limpkin, Aramuspictus",
            "Europeangallinule, Porphyrioporphyrio",
            "Americancoot, marshhen, mudhen, waterhen, Fulicaamericana",
            "bustard",
            "ruddyturnstone, Arenariainterpres",
            "red-backedsandpiper, dunlin, Eroliaalpina",
            "redshank, Tringatotanus",
            "dowitcher",
            "oystercatcher, oystercatcher",
            "pelican",
            "kingpenguin, Aptenodytespatagonica",
            "albatross, mollymawk",
            "greywhale, graywhale, devilfish, Eschrichtiusgibbosus, Eschrichtiusrobustus",
            "killerwhale, killer, orca, grampus, seawolf, Orcinusorca",
            "dugong, Dugongdugon",
            "sealion",
            "Chihuahua",
            "Japanesespaniel",
            "Maltesedog, Malteseterrier, Maltese",
            "Pekinese, Pekingese, Peke",
            "Shih-Tzu",
            "Blenheimspaniel",
            "papillon",
            "toyterrier",
            "Rhodesianridgeback",
            "Afghanhound, Afghan",
            "basset, bassethound",
            "beagle",
            "bloodhound, sleuthhound",
            "bluetick",
            "black-and-tancoonhound",
            "Walkerhound, Walkerfoxhound",
            "Englishfoxhound",
            "redbone",
            "borzoi, Russianwolfhound",
            "Irishwolfhound",
            "Italiangreyhound",
            "whippet",
            "Ibizanhound, IbizanPodenco",
            "Norwegianelkhound, elkhound",
            "otterhound, otterhound",
            "Saluki, gazellehound",
            "Scottishdeerhound, deerhound",
            "Weimaraner",
            "Staffordshirebullterrier, Staffordshirebullterrier",
            "AmericanStaffordshireterrier, Staffordshireterrier, Americanpitbullterrier, pitbullterrier",
            "Bedlingtonterrier",
            "Borderterrier",
            "Kerryblueterrier",
            "Irishterrier",
            "Norfolkterrier",
            "Norwichterrier",
            "Yorkshireterrier",
            "wire-hairedfoxterrier",
            "Lakelandterrier",
            "Sealyhamterrier, Sealyham",
            "Airedale, Airedaleterrier",
            "cairn, cairnterrier",
            "Australianterrier",
            "DandieDinmont, DandieDinmontterrier",
            "Bostonbull, Bostonterrier",
            "miniatureschnauzer",
            "giantschnauzer",
            "standardschnauzer",
            "Scotchterrier, Scottishterrier, Scottie",
            "Tibetanterrier, chrysanthemumdog",
            "silkyterrier, Sydneysilky",
            "soft-coatedwheatenterrier",
            "WestHighlandwhiteterrier",
            "Lhasa, Lhasaapso",
            "flat-coatedretriever",
            "curly-coatedretriever",
            "goldenretriever",
            "Labradorretriever",
            "ChesapeakeBayretriever",
            "Germanshort-hairedpointer",
            "vizsla, Hungarianpointer",
            "Englishsetter",
            "Irishsetter, redsetter",
            "Gordonsetter",
            "Brittanyspaniel",
            "clumber, clumberspaniel",
            "Englishspringer, Englishspringerspaniel",
            "Welshspringerspaniel",
            "cockerspaniel, Englishcockerspaniel, cocker",
            "Sussexspaniel",
            "Irishwaterspaniel",
            "kuvasz",
            "schipperke",
            "groenendael",
            "malinois",
            "briard",
            "kelpie",
            "komondor",
            "OldEnglishsheepdog, bobtail",
            "Shetlandsheepdog, Shetlandsheepdog, Shetland",
            "collie",
            "Bordercollie",
            "BouvierdesFlandres, BouviersdesFlandres",
            "Rottweiler",
            "Germanshepherd, Germanshepherddog, Germanpolicedog, alsatian",
            "Doberman, Dobermanpinscher",
            "miniaturepinscher",
            "GreaterSwissMountaindog",
            "Bernesemountaindog",
            "Appenzeller",
            "EntleBucher",
            "boxer",
            "bullmastiff",
            "Tibetanmastiff",
            "Frenchbulldog",
            "GreatDane",
            "SaintBernard, StBernard",
            "Eskimodog, husky",
            "malamute, malemute, Alaskanmalamute",
            "Siberianhusky",
            "dalmatian, coachdog, carriagedog",
            "affenpinscher, monkeypinscher, monkeydog",
            "basenji",
            "pug, pug-dog",
            "Leonberg",
            "Newfoundland, Newfoundlanddog",
            "GreatPyrenees",
            "Samoyed, Samoyede",
            "Pomeranian",
            "chow, chowchow",
            "keeshond",
            "Brabancongriffon",
            "Pembroke, PembrokeWelshcorgi",
            "Cardigan, CardiganWelshcorgi",
            "toypoodle",
            "miniaturepoodle",
            "standardpoodle",
            "Mexicanhairless",
            "timberwolf, greywolf, graywolf, Canislupus",
            "whitewolf, Arcticwolf, Canislupustundrarum",
            "redwolf, manedwolf, Canisrufus, Canisniger",
            "coyote, prairiewolf, brushwolf, Canislatrans",
            "dingo, warrigal, warragal, Canisdingo",
            "dhole, Cuonalpinus",
            "Africanhuntingdog, hyenadog, Capehuntingdog, Lycaonpictus",
            "hyena, hyaena",
            "redfox, Vulpesvulpes",
            "kitfox, Vulpesmacrotis",
            "Arcticfox, whitefox, Alopexlagopus",
            "greyfox, grayfox, Urocyoncinereoargenteus",
            "tabby, tabbycat",
            "tigercat",
            "Persiancat",
            "Siamesecat, Siamese",
            "Egyptiancat",
            "cougar, puma, catamount, mountainlion, painter, panther, Felisconcolor",
            "lynx, catamount",
            "leopard, Pantherapardus",
            "snowleopard, ounce, Pantherauncia",
            "jaguar, panther, Pantheraonca, Felisonca",
            "lion, kingofbeasts, Pantheraleo",
            "tiger, Pantheratigris",
            "cheetah, chetah, Acinonyxjubatus",
            "brownbear, bruin, Ursusarctos",
            "Americanblackbear, blackbear, Ursusamericanus, Euarctosamericanus",
            "icebear, polarbear, UrsusMaritimus, Thalarctosmaritimus",
            "slothbear, Melursusursinus, Ursusursinus",
            "mongoose",
            "meerkat, mierkat",
            "tigerbeetle",
            "ladybug, ladybeetle, ladybeetle, ladybird, ladybirdbeetle",
            "groundbeetle, carabidbeetle",
            "long-hornedbeetle, longicorn, longicornbeetle",
            "leafbeetle, chrysomelid",
            "dungbeetle",
            "rhinocerosbeetle",
            "weevil",
            "fly",
            "bee",
            "ant, emmet, pismire",
            "grasshopper, hopper",
            "cricket",
            "walkingstick, walkingstick, stickinsect",
            "cockroach, roach",
            "mantis, mantid",
            "cicada, cicala",
            "leafhopper",
            "lacewing, lacewingfly",
            "dragonfly, darningneedle, devilsdarningneedle, sewingneedle, snakefeeder, snakedoctor, mosquitohawk, skeeterhawk",
            "damselfly",
            "admiral",
            "ringlet, ringletbutterfly",
            "monarch, monarchbutterfly, milkweedbutterfly, Danausplexippus",
            "cabbagebutterfly",
            "sulphurbutterfly, sulfurbutterfly",
            "lycaenid, lycaenidbutterfly",
            "starfish, seastar",
            "seaurchin",
            "seacucumber, holothurian",
            "woodrabbit, cottontail, cottontailrabbit",
            "hare",
            "Angora, Angorarabbit",
            "hamster",
            "porcupine, hedgehog",
            "foxsquirrel, easternfoxsquirrel, Sciurusniger",
            "marmot",
            "beaver",
            "guineapig, Caviacobaya",
            "sorrel",
            "zebra",
            "hog, pig, grunter, squealer, Susscrofa",
            "wildboar, boar, Susscrofa",
            "warthog",
            "hippopotamus, hippo, riverhorse, Hippopotamusamphibius",
            "ox",
            "waterbuffalo, waterox, Asiaticbuffalo, Bubalusbubalis",
            "bison",
            "ram, tup",
            "bighorn, bighornsheep, cimarron, RockyMountainbighorn, RockyMountainsheep, Oviscanadensis",
            "ibex, Capraibex",
            "hartebeest",
            "impala, Aepycerosmelampus",
            "gazelle",
            "Arabiancamel, dromedary, Camelusdromedarius",
            "llama",
            "weasel",
            "mink",
            "polecat, fitch, foulmart, foumart, Mustelaputorius",
            "black-footedferret, ferret, Mustelanigripes",
            "otter",
            "skunk, polecat, woodpussy",
            "badger",
            "armadillo",
            "three-toedsloth, ai, Bradypustridactylus",
            "orangutan, orang, orangutang, Pongopygmaeus",
            "gorilla, Gorillagorilla",
            "chimpanzee, chimp, Pantroglodytes",
            "gibbon, Hylobateslar",
            "siamang, Hylobatessyndactylus, Symphalangussyndactylus",
            "guenon, guenonmonkey",
            "patas, hussarmonkey, Erythrocebuspatas",
            "baboon",
            "macaque",
            "langur",
            "colobus, colobusmonkey",
            "proboscismonkey, Nasalislarvatus",
            "marmoset",
            "capuchin, ringtail, Cebuscapucinus",
            "howlermonkey, howler",
            "titi, titimonkey",
            "spidermonkey, Atelesgeoffroyi",
            "squirrelmonkey, Saimirisciureus",
            "Madagascarcat, ring-tailedlemur, Lemurcatta",
            "indri, indris, Indriindri, Indribrevicaudatus",
            "Indianelephant, Elephasmaximus",
            "Africanelephant, Loxodontaafricana",
            "lesserpanda, redpanda, panda, bearcat, catbear, Ailurusfulgens",
            "giantpanda, panda, pandabear, coonbear, Ailuropodamelanoleuca",
            "barracouta, snoek",
            "eel",
            "coho, cohoe, cohosalmon, bluejack, silversalmon, Oncorhynchuskisutch",
            "rockbeauty, Holocanthustricolor",
            "anemonefish",
            "sturgeon",
            "gar, garfish, garpike, billfish, Lepisosteusosseus",
            "lionfish",
            "puffer, pufferfish, blowfish, globefish",
            "abacus",
            "abaya",
            "academicgown, academicrobe, judgesrobe",
            "accordion, pianoaccordion, squeezebox",
            "acousticguitar",
            "aircraftcarrier, carrier, flattop, attackaircraftcarrier",
            "airliner",
            "airship, dirigible",
            "altar",
            "ambulance",
            "amphibian, amphibiousvehicle",
            "analogclock",
            "apiary, beehouse",
            "apron",
            "ashcan, trashcan, garbagecan, wastebin, ashbin, ash-bin, ashbin, dustbin, trashbarrel, trashbin",
            "assaultrifle, assaultgun",
            "backpack, backpack, knapsack, packsack, rucksack, haversack",
            "bakery, bakeshop, bakehouse",
            "balancebeam, beam",
            "balloon",
            "ballpoint, ballpointpen, ballpen, Biro",
            "BandAid",
            "banjo",
            "bannister, banister, balustrade, balusters, handrail",
            "barbell",
            "barberchair",
            "barbershop",
            "barn",
            "barometer",
            "barrel, cask",
            "barrow, gardencart, lawncart, wheelbarrow",
            "baseball",
            "basketball",
            "bassinet",
            "bassoon",
            "bathingcap, swimmingcap",
            "bathtowel",
            "bathtub, bathingtub, bath, tub",
            "beachwagon, stationwagon, wagon, estatecar, beachwaggon, stationwaggon, waggon",
            "beacon, lighthouse, beaconlight, pharos",
            "beaker",
            "bearskin, busby, shako",
            "beerbottle",
            "beerglass",
            "bellcote, bellcot",
            "bib",
            "bicycle-built-for-two, tandembicycle, tandem",
            "bikini, two-piece",
            "binder, ring-binder",
            "binoculars, fieldglasses, operaglasses",
            "birdhouse",
            "boathouse",
            "bobsled, bobsleigh, bob",
            "bolotie, bolo, bolatie, bola",
            "bonnet, pokebonnet",
            "bookcase",
            "bookshop, bookstore, bookstall",
            "bottlecap",
            "bow",
            "bowtie, bow-tie, bowtie",
            "brass, memorialtablet, plaque",
            "brassiere, bra, bandeau",
            "breakwater, groin, groyne, mole, bulwark, seawall, jetty",
            "breastplate, aegis, egis",
            "broom",
            "bucket, pail",
            "buckle",
            "bulletproofvest",
            "bullettrain, bullet",
            "butchershop, meatmarket",
            "cab, hack, taxi, taxicab",
            "caldron, cauldron",
            "candle, taper, waxlight",
            "cannon",
            "canoe",
            "canopener, tinopener",
            "cardigan",
            "carmirror",
            "carousel, carrousel, merry-go-round, roundabout, whirligig",
            "carpenterskit, toolkit",
            "carton",
            "carwheel",
            "cashmachine, cashdispenser, automatedtellermachine, automatictellermachine, automatedteller, automaticteller, ATM",
            "cassette",
            "cassetteplayer",
            "castle",
            "catamaran",
            "CDplayer",
            "cello, violoncello",
            "cellulartelephone, cellularphone, cellphone, cell, mobilephone",
            "chain",
            "chainlinkfence",
            "chainmail, ringmail, mail, chainarmor, chainarmour, ringarmor, ringarmour",
            "chainsaw, chainsaw",
            "chest",
            "chiffonier, commode",
            "chime, bell, gong",
            "chinacabinet, chinacloset",
            "Christmasstocking",
            "church, churchbuilding",
            "cinema, movietheater, movietheatre, moviehouse, picturepalace",
            "cleaver, meatcleaver, chopper",
            "cliffdwelling",
            "cloak",
            "clog, geta, patten, sabot",
            "cocktailshaker",
            "coffeemug",
            "coffeepot",
            "coil, spiral, volute, whorl, helix",
            "combinationlock",
            "computerkeyboard, keypad",
            "confectionery, confectionary, candystore",
            "containership, containership, containervessel",
            "convertible",
            "corkscrew, bottlescrew",
            "cornet, horn, trumpet, trump",
            "cowboyboot",
            "cowboyhat, ten-gallonhat",
            "cradle",
            "crane",
            "crashhelmet",
            "crate",
            "crib, cot",
            "CrockPot",
            "croquetball",
            "crutch",
            "cuirass",
            "dam, dike, dyke",
            "desk",
            "desktopcomputer",
            "dialtelephone, dialphone",
            "diaper, nappy, napkin",
            "digitalclock",
            "digitalwatch",
            "diningtable, board",
            "dishrag, dishcloth",
            "dishwasher, dishwasher, dishwashingmachine",
            "diskbrake, discbrake",
            "dock, dockage, dockingfacility",
            "dogsled, dogsled, dogsleigh",
            "dome",
            "doormat, welcomemat",
            "drillingplatform, offshorerig",
            "drum, membranophone, tympan",
            "drumstick",
            "dumbbell",
            "Dutchoven",
            "electricfan, blower",
            "electricguitar",
            "electriclocomotive",
            "entertainmentcenter",
            "envelope",
            "espressomaker",
            "facepowder",
            "featherboa, boa",
            "file, filecabinet, filingcabinet",
            "fireboat",
            "fireengine, firetruck",
            "firescreen, fireguard",
            "flagpole, flagstaff",
            "flute, transverseflute",
            "foldingchair",
            "footballhelmet",
            "forklift",
            "fountain",
            "fountainpen",
            "four-poster",
            "freightcar",
            "Frenchhorn, horn",
            "fryingpan, frypan, skillet",
            "furcoat",
            "garbagetruck, dustcart",
            "gasmask, respirator, gashelmet",
            "gaspump, gasolinepump, petrolpump, islanddispenser",
            "goblet",
            "go-kart",
            "golfball",
            "golfcart, golfcart",
            "gondola",
            "gong, tam-tam",
            "gown",
            "grandpiano, grand",
            "greenhouse, nursery, glasshouse",
            "grille, radiatorgrille",
            "grocerystore, grocery, foodmarket, market",
            "guillotine",
            "hairslide",
            "hairspray",
            "halftrack",
            "hammer",
            "hamper",
            "handblower, blowdryer, blowdrier, hairdryer, hairdrier",
            "hand-heldcomputer, hand-heldmicrocomputer",
            "handkerchief, hankie, hanky, hankey",
            "harddisc, harddisk, fixeddisk",
            "harmonica, mouthorgan, harp, mouthharp",
            "harp",
            "harvester, reaper",
            "hatchet",
            "holster",
            "hometheater, hometheatre",
            "honeycomb",
            "hook, claw",
            "hoopskirt, crinoline",
            "horizontalbar, highbar",
            "horsecart, horse-cart",
            "hourglass",
            "iPod",
            "iron, smoothingiron",
            "jack-o-lantern",
            "jean, bluejean, denim",
            "jeep, landrover",
            "jersey, T-shirt, teeshirt",
            "jigsawpuzzle",
            "jinrikisha, ricksha, rickshaw",
            "joystick",
            "kimono",
            "kneepad",
            "knot",
            "labcoat, laboratorycoat",
            "ladle",
            "lampshade, lampshade",
            "laptop, laptopcomputer",
            "lawnmower, mower",
            "lenscap, lenscover",
            "letteropener, paperknife, paperknife",
            "library",
            "lifeboat",
            "lighter, light, igniter, ignitor",
            "limousine, limo",
            "liner, oceanliner",
            "lipstick, liprouge",
            "Loafer",
            "lotion",
            "loudspeaker, speaker, speakerunit, loudspeakersystem, speakersystem",
            "loupe, jewelersloupe",
            "lumbermill, sawmill",
            "magneticcompass",
            "mailbag, postbag",
            "mailbox, letterbox",
            "maillot",
            "maillot, tanksuit",
            "manholecover",
            "maraca",
            "marimba, xylophone",
            "mask",
            "matchstick",
            "maypole",
            "maze, labyrinth",
            "measuringcup",
            "medicinechest, medicinecabinet",
            "megalith, megalithicstructure",
            "microphone, mike",
            "microwave, microwaveoven",
            "militaryuniform",
            "milkcan",
            "minibus",
            "miniskirt, mini",
            "minivan",
            "missile",
            "mitten",
            "mixingbowl",
            "mobilehome, manufacturedhome",
            "ModelT",
            "modem",
            "monastery",
            "monitor",
            "moped",
            "mortar",
            "mortarboard",
            "mosque",
            "mosquitonet",
            "motorscooter, scooter",
            "mountainbike, all-terrainbike, off-roader",
            "mountaintent",
            "mouse, computermouse",
            "mousetrap",
            "movingvan",
            "muzzle",
            "nail",
            "neckbrace",
            "necklace",
            "nipple",
            "notebook, notebookcomputer",
            "obelisk",
            "oboe, hautboy, hautbois",
            "ocarina, sweetpotato",
            "odometer, hodometer, mileometer, milometer",
            "oilfilter",
            "organ, pipeorgan",
            "oscilloscope, scope, cathode-rayoscilloscope, CRO",
            "overskirt",
            "oxcart",
            "oxygenmask",
            "packet",
            "paddle, boatpaddle",
            "paddlewheel, paddlewheel",
            "padlock",
            "paintbrush",
            "pajama, pyjama, pjs, jammies",
            "palace",
            "panpipe, pandeanpipe, syrinx",
            "papertowel",
            "parachute, chute",
            "parallelbars, bars",
            "parkbench",
            "parkingmeter",
            "passengercar, coach, carriage",
            "patio, terrace",
            "pay-phone, pay-station",
            "pedestal, plinth, footstall",
            "pencilbox, pencilcase",
            "pencilsharpener",
            "perfume, essence",
            "Petridish",
            "photocopier",
            "pick, plectrum, plectron",
            "pickelhaube",
            "picketfence, paling",
            "pickup, pickuptruck",
            "pier",
            "piggybank, pennybank",
            "pillbottle",
            "pillow",
            "ping-pongball",
            "pinwheel",
            "pirate, pirateship",
            "pitcher, ewer",
            "plane, carpentersplane, woodworkingplane",
            "planetarium",
            "plasticbag",
            "platerack",
            "plow, plough",
            "plunger, plumbershelper",
            "Polaroidcamera, PolaroidLandcamera",
            "pole",
            "policevan, policewagon, paddywagon, patrolwagon, wagon, blackMaria",
            "poncho",
            "pooltable, billiardtable, snookertable",
            "popbottle, sodabottle",
            "pot, flowerpot",
            "potterswheel",
            "powerdrill",
            "prayerrug, prayermat",
            "printer",
            "prison, prisonhouse",
            "projectile, missile",
            "projector",
            "puck, hockeypuck",
            "punchingbag, punchbag, punchingball, punchball",
            "purse",
            "quill, quillpen",
            "quilt, comforter, comfort, puff",
            "racer, racecar, racingcar",
            "racket, racquet",

            "radiator",
            "radio, wireless",
            "radiotelescope, radioreflector",
            "rainbarrel",
            "recreationalvehicle, RV, R.V.",
            "reel",
            "reflexcamera",
            "refrigerator, icebox",
            "remotecontrol, remote",
            "restaurant, eatinghouse, eatingplace, eatery",
            "revolver, six-gun, six-shooter",
            "rifle",
            "rockingchair, rocker",
            "rotisserie",
            "rubbereraser, rubber, pencileraser",
            "rugbyball",
            "rule, ruler",
            "runningshoe",
            "safe",
            "safetypin",
            "saltshaker, saltshaker",
            "sandal",
            "sarong",
            "sax, saxophone",
            "scabbard",
            "scale, weighingmachine",
            "schoolbus",
            "schooner",
            "scoreboard",
            "screen, CRTscreen",
            "screw",
            "screwdriver",
            "seatbelt, seatbelt",
            "sewingmachine",
            "shield, buckler",
            "shoeshop, shoe-shop, shoestore",
            "shoji",
            "shoppingbasket",
            "shoppingcart",
            "shovel",
            "showercap",
            "showercurtain",
            "ski",
            "skimask",
            "sleepingbag",
            "sliderule, slipstick",
            "slidingdoor",
            "slot, one-armedbandit",
            "snorkel",
            "snowmobile",
            "snowplow, snowplough",
            "soapdispenser",
            "soccerball",
            "sock",
            "solardish, solarcollector, solarfurnace",
            "sombrero",
            "soupbowl",
            "spacebar",
            "spaceheater",
            "spaceshuttle",
            "spatula",
            "speedboat",
            "spiderweb, spidersweb",
            "spindle",
            "sportscar, sportcar",
            "spotlight, spot",
            "stage",
            "steamlocomotive",
            "steelarchbridge",
            "steeldrum",
            "stethoscope",
            "stole",
            "stonewall",
            "stopwatch, stopwatch",
            "stove",
            "strainer",
            "streetcar, tram, tramcar, trolley, trolleycar",
            "stretcher",
            "studiocouch, daybed",
            "stupa, tope",
            "submarine, pigboat, sub, U-boat",
            "suit, suitofclothes",
            "sundial",
            "sunglass",
            "sunglasses, darkglasses, shades",
            "sunscreen, sunblock, sunblocker",
            "suspensionbridge",
            "swab, swob, mop",
            "sweatshirt",
            "swimmingtrunks, bathingtrunks",
            "swing",
            "switch, electricswitch, electricalswitch",
            "syringe",
            "tablelamp",
            "tank, armytank, armoredcombatvehicle, armouredcombatvehicle",
            "tapeplayer",
            "teapot",
            "teddy, teddybear",
            "television, televisionsystem",
            "tennisball",
            "thatch, thatchedroof",
            "theatercurtain, theatrecurtain",
            "thimble",
            "thresher, thrasher, threshingmachine",
            "throne",
            "tileroof",
            "toaster",
            "tobaccoshop, tobacconistshop, tobacconist",
            "toiletseat",
            "torch",
            "totempole",
            "towtruck, towcar, wrecker",
            "toyshop",
            "tractor",
            "trailertruck, tractortrailer, truckingrig, rig, articulatedlorry, semi",
            "tray",
            "trenchcoat",
            "tricycle, trike, velocipede",
            "trimaran",
            "tripod",
            "triumphalarch",
            "trolleybus, trolleycoach, tracklesstrolley",
            "trombone",
            "tub, vat",
            "turnstile",
            "typewriterkeyboard",
            "umbrella",
            "unicycle, monocycle",
            "upright, uprightpiano",
            "vacuum, vacuumcleaner",
            "vase",
            "vault",
            "velvet",
            "vendingmachine",
            "vestment",
            "viaduct",
            "violin, fiddle",
            "volleyball",
            "waffleiron",
            "wallclock",
            "wallet, billfold, notecase, pocketbook",
            "wardrobe, closet, press",
            "warplane, militaryplane",
            "washbasin, handbasin, washbowl, lavabo, wash-handbasin",
            "washer, automaticwasher, washingmachine",
            "waterbottle",
            "waterjug",
            "watertower",
            "whiskeyjug",
            "whistle",
            "wig",
            "windowscreen",
            "windowshade",
            "Windsortie",
            "winebottle",
            "wing",
            "wok",
            "woodenspoon",
            "wool, woolen, woollen",
            "wormfence, snakefence, snake-railfence, Virginiafence",
            "wreck",
            "yawl",
            "yurt",
            "website, website, internetsite, site",
            "comicbook",
            "crosswordpuzzle, crossword",
            "streetsign",
            "trafficlight, trafficsignal, stoplight",
            "bookjacket, dustcover, dustjacket, dustwrapper",
            "menu",
            "plate",
            "guacamole",
            "consomme",
            "hotpot, hotpot",
            "trifle",
            "icecream, icecream",
            "icelolly, lolly, lollipop, popsicle",
            "Frenchloaf",
            "bagel, beigel",
            "pretzel",
            "cheeseburger",
            "hotdog, hotdog, redhot",
            "mashedpotato",
            "headcabbage",
            "broccoli",
            "cauliflower",
            "zucchini, courgette",
            "spaghettisquash",
            "acornsquash",
            "butternutsquash",
            "cucumber, cuke",
            "artichoke, globeartichoke",
            "bellpepper",
            "cardoon",
            "mushroom",
            "GrannySmith",
            "strawberry",
            "orange",
            "lemon",
            "fig",
            "pineapple, ananas",
            "banana",
            "jackfruit, jak, jack",
            "custardapple",
            "pomegranate",
            "hay",
            "carbonara",
            "chocolatesauce, chocolatesyrup",
            "dough",
            "meatloaf, meatloaf",
            "pizza, pizzapie",
            "potpie",
            "burrito",
            "redwine",
            "espresso",
            "cup",
            "eggnog",
            "alp",
            "bubble",
            "cliff, drop, drop-off",
            "coralreef",
            "geyser",
            "lakeside, lakeshore",
            "promontory, headland, head, foreland",
            "sandbar, sandbar",
            "seashore, coast, seacoast, sea-coast",
            "valley, vale",
            "volcano",
            "ballplayer, baseballplayer",
            "groom, bridegroom",
            "scubadiver",
            "rapeseed",
            "daisy",
            "yellowladysslipper, yellowlady-slipper, Cypripediumcalceolus, Cypripediumparviflorum",
            "corn",
            "acorn",
            "hip, rosehip, rosehip",
            "buckeye, horsechestnut, conker",
            "coralfungus",
            "agaric",
            "gyromitra",
            "stinkhorn, carrionfungus",
            "earthstar",
            "hen-of-the-woods, henofthewoods, Polyporusfrondosus, Grifolafrondosa",
            "bolete",
            "ear, spike, capitulum",
            "toilettissue, toiletpaper, bathroomtissue"
        };
        #endregion

        public static Dictionary<int, float> get_top5(float[] p)
        {
            Dictionary<int, float> res = new Dictionary<int, float>(5);
            for(int j = 0; j < 5; j++)
            {
                   var maxi = 0;
                var maxv = 0f;
                for(int i = 0; i < p.Length; i++)
                {
                    if((p[i] > maxv) && (!res.Keys.Contains(i)))
                    {
                        maxv = p[i];
                        maxi = i;
                    }
                }
                res.Add(maxi, maxv);
            }
            return res;
        }

        public static void Main(string[] args)
        {
            var m = models.squeezenet1_1(true);
            var y = m.forward(load("C:\\1.jpg"));
            var pred = get_top5(y.squeeze(0).dotnet() as float[]);
            foreach(var p in pred)
            {
                Console.WriteLine(imagenet_classes[p.Key]);
            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}