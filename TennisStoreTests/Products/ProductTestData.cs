using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Domain.CrossCutting.Products;
using Domain.MasterData.ProductAggregate;

namespace TennisStoreTests.Products
{
    [ExcludeFromCodeCoverage]
    public static class ProductTestData
    {
        public static readonly IReadOnlyList<Product> Products = new List<Product>
        {
            new Product("1", "Babolat Pure Control Tour",
                "Like the Pure Storm Tour GT, the Pure Control Tour provides strong intermediates and advanced players with a wonderful blend of control, stability and feel. With this update Babolat retains the crisp graphite layup while strategically boosting the flexibility with a new material called Flex Carbon. The result is a comfortably crisp response that feels decidedly softer and more plaible than Babolat's stiffer, more modern player's sticks. Though nearly 12 ounces, this racquet's head light balance and manageable swingweight (316 RDC) give it a refreshingly fast feel from the baseline, a fact that lends itself to higher swing speeds and heavier spin. Factor in the exceptional control and you have a racquet that supplies aggressive players with the needed confidence to attack the ball. At net this one holds up well against pace, but its real strength is mobility, making it great on fast exchanges. Ultimately, the Pure Control Tour places a very effective combination of control and mobility in the hands of 4.5+ players. Those looking for a little extra flexibility and feel should love this one.",
                1, 159.00M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "27",
                        SizeUnitOfMeasure = UnitMeasure.Inches.ToString()
                    }
                },
                Weight = 11.9,
                WeightUnitMeasureCode = UnitMeasure.Ounces.ToString()
            },
            new Product("2", "Babolat Pure Strike 100",
                "Babolat's Pure Strike 100 glides through the air with remarkable ease. At under 11 ounces and boasting a very low swingweight (304 RDC), the Pure Strike 100 is great for intermediates who need a lightning fast weapon that can be dispatched with power and purpose. Players who like to pressure their opponents by stepping inside the baseline and taking the ball early will find this racquet wonderfully quick and agile. On groundstrokes the ease of acceleration and open 16x19 string pattern provide the ingredients for fast strokes, big spin and controllable power. Advanced players looking for stability and some mass based power will find plenty of room for weight customization. At net the Pure Strike 100 offers lightning quick handling and plenty of put-away power. As for serves, the fast feel makes it easy to add pace, and the spin-friendly response is perfect for hitting effective slices and kickers. Ultimately, the Pure Strike 100 is a nice option for the 4.0+ player looking for an extremely user-friendly stick with a comfortably crisp response along with pinpoint accuracy and a very fast feel.",
                1, 149)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "27",
                        SizeUnitOfMeasure = UnitMeasure.Inches.ToString()
                    }
                },
                Weight = 10.8,
                WeightUnitMeasureCode = UnitMeasure.Ounces.ToString()
            },
            new Product("3", "Wilson Pro Staff RF97 Autograph",
                "The Pro Staff RF97 Autograph is no ordinary racquet. For starters it deploys crucial elements of Wilson's timeless Pro Staff formula, including a graphite/Kevlar layup, headlight balance and Perimeter Weight System. Taken together these features add up to a truly classic feel with world class precision. Even more impressive, however, is the man who helped design it. His name is Roger Federer and the RF97 was specially engineered for him. You will even find Roger's \"go to\" hybrid, tension and overgrip listed on the inside of the shaft. Unlike the Original 6.0 used by the young Fed, this re-invented Pro Staff has a wider, more rounded beam to better suit the power of the modern game. At 12.6 ounces strung, it should come as no surprise that this stick does not get pushed around. With its tour level stability and huge plow-through, the RF97 is the perfect weapon for trading heavy balls. Our playtesters were not only impressed by the phenomenal control, they also found plenty of power when they were able to deploy the mass. Thanks to the headlight balance, this racquet whips nicely through contact on full swings, a fact that should allow strong players to crank up the head speed when driving the ball through the court. At net the RF97 feels as solid as a rock. Even when the player is stretched out, this stick redirects pace with surprising ease. On serves, Federer's Pro Staff delivers all the control needed to tease the lines. Those who can swing it fast will be rewarded with some very weak replies. Ultimately, as the most modern and evolved version of Wilson's iconic Pro Staff line, this is a must hit for serious players. The fact that it was designed with the help of a true legend makes it a genuine collectible.",
                1, 219.00M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "27",
                        SizeUnitOfMeasure = UnitMeasure.Inches.ToString()
                    }
                },
                Weight = 12.38,
                WeightUnitMeasureCode = UnitMeasure.Ounces.ToString()
            },
            new Product("4", "Wilson Pro Staff 90",
                "With roots that extend all the way back to the Wilson Ultra and legendary Pro Staff 6.0 85, the Pro Staff 90 is a true classic. This one is built for advanced players in search of incredible feel, rock solid stability and surgical precision. Featuring the ultimate player's specs, the Pro Staff 90 includes a 12+ oz weight, headlight balance, thin beam, leather grip and Wilson's tried and true Graphite/Kevlar Layup. It also has Amplifeel Technology in the handle to filter out some of the harsher vibrations. All told these ingredients add up to an unmatched level of feel, precision and plow-through. From the baseline the control on full swings is simply amazing, as is the unmistakably sublime feel when contact is cleanly made. There's also some penetrating power available to those who can get the mass moving. At net the Pro Staff 90 provides remarkable stability and pinpoint accuracy, with enough weight to punch the ball deep. All in all, this venerable racquet is simply a great option for any serious player who wants to experience the ultimate in precision and stability along with that timeless Pro Staff feel.",
                1, 99.00M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "27",
                        SizeUnitOfMeasure = UnitMeasure.Inches.ToString()
                    }
                },
                Weight = 12.5,
                WeightUnitMeasureCode = UnitMeasure.Ounces.ToString()
            },
            new Product("5", "Nike Men's Winter RF Hybrid Hat",
                "The monogram of Roger Federer graces this unique hat. RF is embroidered on the face of the hat, while Federer is embroidered on the back. A velcro strap makes this hat adjust to fit most people. The underside of the bill is contrasting grey, and there's a mesh insert around the head to control moisture. The hat also features Dri-Fit fabrication to wick away perspiration. Swoosh design trademark embroidered on left side.",
                2, 26.00M),
            new Product("6", "Nike Men's Winter Advantage Cool Polo",
                "Be confident -- and comfortable -- in this bold polo that has a soft cotton feel. This Advantage Cool Polo is a mix of poly and cotton for a luxurious feel. The polo features a slim modern collar, ribbed sleeve cuffs, three-button placket, colorblocked stripes, side vents on hem, and a heat transfer Swoosh on left chest.",
                2, 70.00M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "Small"
                    },
                    new Size
                    {
                        Value = "Medium"
                    },
                    new Size
                    {
                        Value = "Large"
                    }
                },
                Weight = 195,
                WeightUnitMeasureCode = UnitMeasure.Pounds.ToString()
            },
            new Product("7", "Adidas Men's Fall Barricade Bermuda",
                "Lightweight and with plenty of stretch, these adidas Barricade Bermuda shorts will keep you running on the court in comfort. These woven shorts feature a flat waistband with side elastics, front hook closure with Velcro tab, zipper fly, mesh side pockets, laser cut vent holes at sides, and a heat transfer adidas logo at left leg hem.",
                2, 39.00M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "Small"
                    },
                    new Size
                    {
                        Value = "Medium"
                    },
                    new Size
                    {
                        Value = "Large"
                    }
                },
                Weight = 170,
                WeightUnitMeasureCode = UnitMeasure.Pounds.ToString()
            },
            new Product("8", "Adidas Women's Fall Stella McCartney Visor",
                "Protect your eyes from the sun's harmful rays in stylish fashion with the adidas Fall Stella McCartney Visor. It features a pre-curved bill, adjustable back closure, mesh lining on body, absorbent inner sweatband, and a printed adidas Stella McCartney logo at center front.",
                2, 19.99M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "One Size Fits all"
                    }
                }
            },
            new Product("9", "Adidas Barricade 2015 Black/Red Men's Shoe",
                "Completely re-designed to offer a new level of comfort right out of the box while still providing unmatched support, stability and durability. Backed by a six month durability guarantee.", 3, 114.95M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "7"
                    },
                    new Size
                    {
                        Value = "8"
                    },
                    new Size
                    {
                        Value = "9"
                    },
                    new Size
                    {
                        Value = "9.5"
                    },
                    new Size
                    {
                        Value = "10"
                    },
                    new Size
                    {
                        Value = "10.5"
                    },
                    new Size
                    {
                        Value = "11"
                    },
                    new Size
                    {
                        Value = "11.5"
                    },
                    new Size
                    {
                        Value = "12"
                    }
                },
                Color = "Black / White / Solar Red",
                Weight = 14.9,
                WeightUnitMeasureCode = UnitMeasure.Ounces.ToString()
            },
            new Product("10", "Adidas adizero CC Feather III Wh/Grey/Blue",
                "The ultimate in lightweight performance, the new adizero CC Feather III is a perfect choice for the modern player looking for a low-profile, ultra lightweight shoe. The lightweight materials and design will have you tapping into your top gear and tracking down balls all over the court. Sprintframe and Sprintweb technology help lock in the foot while you move, because agility and speed is nothing without control. Under the stable Sprintweb cage in the forefoot is adidas' signature Climacool mesh for the ultimate in breathability. Durability is improved as well with a more resilient outsole and adiTuff rubber on the toe and medial side of the upper. It's also miCoach compatible.",
                3, 69.95M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "7"
                    },
                    new Size
                    {
                        Value = "8"
                    },
                    new Size
                    {
                        Value = "9"
                    },
                    new Size
                    {
                        Value = "9.5"
                    },
                    new Size
                    {
                        Value = "10"
                    },
                    new Size
                    {
                        Value = "10.5"
                    },
                    new Size
                    {
                        Value = "11"
                    },
                    new Size
                    {
                        Value = "11.5"
                    },
                    new Size
                    {
                        Value = "12"
                    }
                },
                Color = "White / Iron Metallic / Amazon Purple",
                Weight = 13.1,
                WeightUnitMeasureCode = UnitMeasure.Ounces.ToString()
            },
            new Product("11", "Nike Zoom Cage 2 Blue",
                "Take the courts in an aggressive fashion with the all-around high performing Zoom Cage 2. Players looking for comfort, stability and durability will find it with this stable replacement of the Air Max Cage. The Drag-On TPU cage provides support and breathability for your foot as the heel collar helps you feel locked in when moving on the court. Nike's signature Zoom cushioning offers a comfortable, plush ride and the XDR rubber outsole has been made to last and is backed by a six month outsole durability guarantee.",
                4, 120M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "5"
                    },
                    new Size
                    {
                        Value = "6"
                    },
                    new Size
                    {
                        Value = "7"
                    },
                    new Size
                    {
                        Value = "8"
                    },
                    new Size
                    {
                        Value = "9"
                    },
                    new Size
                    {
                        Value = "9.5"
                    },
                    new Size
                    {
                        Value = "10"
                    },
                    new Size
                    {
                        Value = "10.5"
                    },
                    new Size
                    {
                        Value = "11"
                    }
                },
                Color = "Stratus Blue / Copa / Blue Lagoon / White",
                Weight = 12.5,
                WeightUnitMeasureCode = UnitMeasure.Ounces.ToString()
            },
            new Product("12", "Nike Free 5.0 TR Fit 5 Print Purple/Green",
                "Athletes looking to take their game to the next level will love the Free 5.0 TR Fit 4 for off-court training sessions. This ultra lightweight shoe has been engineered for athletes for multi-directional movement and was built to support your foot during those off-court training sessions. Breathable and well cushioned, the midsole is flexible and the outsole has strategically placed rubber pods to add to the shoe's traction. Built for the active athlete, this is a stylish shoe to transition into for all your off-court training needs.",
                4, 89.95M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "5"
                    },
                    new Size
                    {
                        Value = "6"
                    },
                    new Size
                    {
                        Value = "7"
                    },
                    new Size
                    {
                        Value = "8"
                    },
                    new Size
                    {
                        Value = "9"
                    },
                    new Size
                    {
                        Value = "9.5"
                    },
                    new Size
                    {
                        Value = "10"
                    },
                    new Size
                    {
                        Value = "10.5"
                    },
                    new Size
                    {
                        Value = "11"
                    }
                },
                Color = "Purple / Green / White / Black",
                Weight = 7.3,
                WeightUnitMeasureCode = UnitMeasure.Ounces.ToString()
            },
            new Product("13", "Wilson Tour Molded 2.0 Red 6-Pack Bag",
                "The Tour Molded 2.0 6 Pack Bag is a great lightweight racquet bag option for the player looking to bring a couple racquets and some extra gear to the courts. The molded outer panels help the bag keep its shape and better protect your equipment. Two large main compartments can hold 6-8 racquets total, while two outer accessory pockets (one large, one small) keep smaller gear organized and easy to get to. Carry the bag with a padded and adjustable shoulder strap that can also be unclipped and removed from the bag.",
                5, 27.95M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "6-8 Racquest"
                    }
                },
                Color = "Red / White"
            },
            new Product("14", "Gamma Live Wire XP 16 String Reel",
                "Live Wire 16 XP features a bundled Live Wire core, surrounded by twisted Live Wire wraps and Zyex Monofilaments. A soft Pearl coating provides added comfort and durability. According to Gamma, Live Wire 16 XP offers maximum power and control, superior durability and a crisp, solid feel. Try this handy 360ft reel for convenience.",
                6, 121.50M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "16",
                        SizeUnitOfMeasure = UnitMeasure.Gauge.ToString()
                    },
                    new Size
                    {
                        Value = "360",
                        SizeUnitOfMeasure = UnitMeasure.Feet.ToString()
                    }
                },
                Color = "Natural"
            },
            new Product("15", "Alpha Gut 2000 16 String",
                "This is one of the best multifilament values on the market. Alpha Gut 2000 offers the comfort and power of a premium multi for less than half the price. We found this string to offer above average control and durability for the breed along with impressive tension maintenance. Ideal for the player who values comfort above all else. Perfect for the player with short or compact strokes. Also great for adding comfort to a hybrid or stiff racquet.",
                6, 5.9M)
            {
                Sizes = new List<Size>
                {
                    new Size
                    {
                        Value = "16",
                        SizeUnitOfMeasure = UnitMeasure.Gauge.ToString()
                    },
                    new Size
                    {
                        Value = "40",
                        SizeUnitOfMeasure = UnitMeasure.Feet.ToString()
                    }
                },
                Color = "White"
            }
        };

        public static readonly IReadOnlyList<ProductCategory> ProductCategories = new List<ProductCategory>
        {
            new ProductCategory(1, "Racquet"),
            new ProductCategory(2, "Apparel"),
            new ProductCategory(3, "Men's Shoes"),
            new ProductCategory(4, "Women's Shoes"),
            new ProductCategory(5, "Bags"),
            new ProductCategory(6, "Strings")
        };
    }
}