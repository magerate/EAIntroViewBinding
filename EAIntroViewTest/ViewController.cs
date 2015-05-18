using System;

using UIKit;

using EAIntroViews;

namespace EAIntroViewTest
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            ShowIntroWithCrossDissolve ();
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        private void ShowIntroWithCrossDissolve()
        {
            EAIntroPage page1 = new EAIntroPage ();
            page1.Title = "Hello world";
            page1.Desc = "sampleDescription1 fdasfas fdasfsa";
            page1.BgImage = UIImage.FromBundle ("bg1");
            page1.TitleIconView = new UIImageView (UIImage.FromBundle ("title1"));

            EAIntroPage page2 = new EAIntroPage ();
            page2.Title = "This is page 2";
            page2.Desc = "sampleDescription2 fdasf fasfs";
            page2.BgImage = UIImage.FromBundle("bg2");
            page2.TitleIconView = new UIImageView(UIImage.FromBundle("title2"));

//            EAIntroPage *page3 = [EAIntroPage page];
//            page3.Title = @"This is page 3";
//            page3.Desc = sampleDescription3;
//            page3.BgImage = [UIImage imageNamed:@"bg3"];
//            page3.TitleIconView = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"Title3"]];
//
//            EAIntroPage *page4 = [EAIntroPage page];
//            page4.Title = @"This is page 4";
//            page4.Desc = sampleDescription4;
//            page4.BgImage = [UIImage imageNamed:@"bg4"];
//            page4.TitleIconView = [[UIImageView alloc] initWithImage:[UIImage imageNamed:@"Title4"]];

            EAIntroView intro = new EAIntroView (View.Bounds, new []{ page1, page2 });
            intro.ShowInView (View, 0.3f);
        }

       
    }
}

