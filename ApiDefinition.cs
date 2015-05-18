using System;

using UIKit;
using ObjCRuntime;
using Foundation;
using CoreGraphics;

namespace EAIntroViews {

    // @interface EAIntroPage : NSObject
    [BaseType (typeof (NSObject))]
    interface EAIntroPage {

        // @property (nonatomic, strong) UIImage * bgImage;
        [Export ("bgImage", ArgumentSemantic.Retain)]
        UIImage BgImage { get; set; }

        // @property (nonatomic, strong) UIColor * bgColor;
        [Export ("bgColor", ArgumentSemantic.Retain)]
        UIColor BgColor { get; set; }

        // @property (assign, nonatomic) BOOL showTitleView;
        [Export ("showTitleView", ArgumentSemantic.UnsafeUnretained)]
        bool ShowTitleView { get; set; }

        // @property (nonatomic, strong) UIView * titleIconView;
        [Export ("titleIconView", ArgumentSemantic.Retain)]
        UIView TitleIconView { get; set; }

        // @property (assign, nonatomic) CGFloat titleIconPositionY;
        [Export ("titleIconPositionY", ArgumentSemantic.UnsafeUnretained)]
        nfloat TitleIconPositionY { get; set; }

        // @property (nonatomic, strong) NSString * title;
        [Export ("title", ArgumentSemantic.Retain)]
        string Title { get; set; }

        // @property (nonatomic, strong) UIFont * titleFont;
        [Export ("titleFont", ArgumentSemantic.Retain)]
        UIFont TitleFont { get; set; }

        // @property (nonatomic, strong) UIColor * titleColor;
        [Export ("titleColor", ArgumentSemantic.Retain)]
        UIColor TitleColor { get; set; }

        // @property (assign, nonatomic) CGFloat titlePositionY;
        [Export ("titlePositionY", ArgumentSemantic.UnsafeUnretained)]
        nfloat TitlePositionY { get; set; }

        // @property (nonatomic, strong) NSString * desc;
        [Export ("desc", ArgumentSemantic.Retain)]
        string Desc { get; set; }

        // @property (nonatomic, strong) UIFont * descFont;
        [Export ("descFont", ArgumentSemantic.Retain)]
        UIFont DescFont { get; set; }

        // @property (nonatomic, strong) UIColor * descColor;
        [Export ("descColor", ArgumentSemantic.Retain)]
        UIColor DescColor { get; set; }

        // @property (assign, nonatomic) CGFloat descWidth;
        [Export ("descWidth", ArgumentSemantic.UnsafeUnretained)]
        nfloat DescWidth { get; set; }

        // @property (assign, nonatomic) CGFloat descPositionY;
        [Export ("descPositionY", ArgumentSemantic.UnsafeUnretained)]
        nfloat DescPositionY { get; set; }

        // @property (nonatomic, strong) NSArray * subviews;
        [Export ("subviews", ArgumentSemantic.Retain)]
        NSObject [] Subviews { get; set; }

        // @property (assign, nonatomic) CGFloat alpha;
        [Export ("alpha", ArgumentSemantic.UnsafeUnretained)]
        nfloat Alpha { get; set; }

        // @property (copy, nonatomic) VoidBlock onPageDidLoad;
        [Export ("onPageDidLoad", ArgumentSemantic.Copy)]
        Action OnPageDidLoad { get; set; }

        // @property (copy, nonatomic) VoidBlock onPageDidAppear;
        [Export ("onPageDidAppear", ArgumentSemantic.Copy)]
        Action OnPageDidAppear { get; set; }

        // @property (copy, nonatomic) VoidBlock onPageDidDisappear;
        [Export ("onPageDidDisappear", ArgumentSemantic.Copy)]
        Action OnPageDidDisappear { get; set; }

        // @property (nonatomic, strong) UIView * customView;
        [Export ("customView", ArgumentSemantic.Retain)]
        UIView CustomView { get; set; }

        // @property (readonly, nonatomic, strong) UIView * pageView;
        [Export ("pageView", ArgumentSemantic.Retain)]
        UIView PageView { get; }

        // +(instancetype)page;
        [Static, Export ("page")]
        EAIntroPage Page ();

        // +(instancetype)pageWithCustomView:(UIView *)customV;
        [Static, Export ("pageWithCustomView:")]
        EAIntroPage PageWithCustomView (UIView customV);

        // +(instancetype)pageWithCustomViewFromNibNamed:(NSString *)nibName;
        [Static, Export ("pageWithCustomViewFromNibNamed:")]
        EAIntroPage PageWithCustomViewFromNibNamed (string nibName);
    }

    // @interface EARestrictedScrollView : UIScrollView
    [BaseType (typeof (UIScrollView))]
    interface EARestrictedScrollView {

        // @property (assign, nonatomic) CGRect restrictionArea;
        [Export ("restrictionArea", ArgumentSemantic.UnsafeUnretained)]
        CGRect RestrictionArea { get; set; }

        // @property (assign, nonatomic, getter = alignedContentOffset, setter = setAlignedContentOffset:) CGPoint contentOffset;
        [Export ("contentOffset", ArgumentSemantic.UnsafeUnretained)]
        CGPoint ContentOffset { [Bind ("alignedContentOffset")] get; [Bind ("setAlignedContentOffset:")] set; }

        // -(void)setContentOffset:(CGPoint)contentOffset;
//        [Availability (Unavailable = Platform.iOS | Platform.Mac)]
        [Export ("setContentOffset:")]
        void SetContentOffset (CGPoint contentOffset);

        // -(CGPoint)contentOffset;
//        [Availability (Unavailable = Platform.iOS | Platform.Mac)]
//        [Export ("contentOffset")]
//        CGPoint ContentOffset ();
    }

    // @protocol EAIntroDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof (NSObject))]
    interface EAIntroDelegate {

        // @optional -(void)introDidFinish:(EAIntroView *)introView;
        [Export ("introDidFinish:")]
        void IntroDidFinish (EAIntroView introView);

        // @optional -(void)intro:(EAIntroView *)introView pageAppeared:(EAIntroPage *)page withIndex:(NSUInteger)pageIndex;
        [Export ("intro:pageAppeared:withIndex:")]
        void PageAppeared (EAIntroView introView, EAIntroPage page, nuint pageIndex);

        // @optional -(void)intro:(EAIntroView *)introView pageStartScrolling:(EAIntroPage *)page withIndex:(NSUInteger)pageIndex;
        [Export ("intro:pageStartScrolling:withIndex:")]
        void PageStartScrolling (EAIntroView introView, EAIntroPage page, nuint pageIndex);

        // @optional -(void)intro:(EAIntroView *)introView pageEndScrolling:(EAIntroPage *)page withIndex:(NSUInteger)pageIndex;
        [Export ("intro:pageEndScrolling:withIndex:")]
        void PageEndScrolling (EAIntroView introView, EAIntroPage page, nuint pageIndex);
    }

    // @interface EAIntroView : UIView <UIScrollViewDelegate>
    [BaseType (typeof (UIView))]
    interface EAIntroView : IUIScrollViewDelegate {

        // -(id)initWithFrame:(CGRect)frame andPages:(NSArray *)pagesArray;
        [Export ("initWithFrame:andPages:")]
        IntPtr Constructor (CGRect frame, NSObject [] pagesArray);

        // @property (nonatomic, weak) id<EAIntroDelegate> delegate;
        [Export ("delegate", ArgumentSemantic.Weak)]
        [NullAllowed]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, weak) id<EAIntroDelegate> delegate;
        [Wrap ("WeakDelegate")]
        EAIntroDelegate Delegate { get; set; }

        // @property (assign, nonatomic) BOOL swipeToExit;
        [Export ("swipeToExit", ArgumentSemantic.UnsafeUnretained)]
        bool SwipeToExit { get; set; }

        // @property (assign, nonatomic) BOOL tapToNext;
        [Export ("tapToNext", ArgumentSemantic.UnsafeUnretained)]
        bool TapToNext { get; set; }

        // @property (assign, nonatomic) BOOL hideOffscreenPages;
        [Export ("hideOffscreenPages", ArgumentSemantic.UnsafeUnretained)]
        bool HideOffscreenPages { get; set; }

        // @property (assign, nonatomic) BOOL easeOutCrossDisolves;
        [Export ("easeOutCrossDisolves", ArgumentSemantic.UnsafeUnretained)]
        bool EaseOutCrossDisolves { get; set; }

        // @property (assign, nonatomic) BOOL useMotionEffects;
        [Export ("useMotionEffects", ArgumentSemantic.UnsafeUnretained)]
        bool UseMotionEffects { get; set; }

        // @property (assign, nonatomic) CGFloat motionEffectsRelativeValue;
        [Export ("motionEffectsRelativeValue", ArgumentSemantic.UnsafeUnretained)]
        nfloat MotionEffectsRelativeValue { get; set; }

        // @property (nonatomic, strong) UIView * titleView;
        [Export ("titleView", ArgumentSemantic.Retain)]
        UIView TitleView { get; set; }

        // @property (assign, nonatomic) CGFloat titleViewY;
        [Export ("titleViewY", ArgumentSemantic.UnsafeUnretained)]
        nfloat TitleViewY { get; set; }

        // @property (nonatomic, strong) UIImage * bgImage;
        [Export ("bgImage", ArgumentSemantic.Retain)]
        UIImage BgImage { get; set; }

        // @property (assign, nonatomic) UIViewContentMode bgViewContentMode;
        [Export ("bgViewContentMode", ArgumentSemantic.UnsafeUnretained)]
        UIViewContentMode BgViewContentMode { get; set; }

        // @property (nonatomic, strong) UIPageControl * pageControl;
        [Export ("pageControl", ArgumentSemantic.Retain)]
        UIPageControl PageControl { get; set; }

        // @property (assign, nonatomic) CGFloat pageControlY;
        [Export ("pageControlY", ArgumentSemantic.UnsafeUnretained)]
        nfloat PageControlY { get; set; }

        // @property (assign, nonatomic) NSUInteger currentPageIndex;
        [Export ("currentPageIndex", ArgumentSemantic.UnsafeUnretained)]
        nuint CurrentPageIndex { get; set; }

        // @property (readonly, assign, nonatomic) NSUInteger visiblePageIndex;
        [Export ("visiblePageIndex", ArgumentSemantic.UnsafeUnretained)]
        nuint VisiblePageIndex { get; }

        // @property (nonatomic, strong) UIButton * skipButton;
        [Export ("skipButton", ArgumentSemantic.Retain)]
        UIButton SkipButton { get; set; }

        // @property (assign, nonatomic) CGFloat skipButtonY;
        [Export ("skipButtonY", ArgumentSemantic.UnsafeUnretained)]
        nfloat SkipButtonY { get; set; }

        // @property (assign, nonatomic) CGFloat skipButtonSideMargin;
        [Export ("skipButtonSideMargin", ArgumentSemantic.UnsafeUnretained)]
        nfloat SkipButtonSideMargin { get; set; }

        // @property (assign, nonatomic) EAViewAlignment skipButtonAlignment;
        [Export ("skipButtonAlignment", ArgumentSemantic.UnsafeUnretained)]
        EAViewAlignment SkipButtonAlignment { get; set; }

        // @property (assign, nonatomic) BOOL showSkipButtonOnlyOnLastPage;
        [Export ("showSkipButtonOnlyOnLastPage", ArgumentSemantic.UnsafeUnretained)]
        bool ShowSkipButtonOnlyOnLastPage { get; set; }

        // @property (nonatomic, strong) EARestrictedScrollView * scrollView;
        [Export ("scrollView", ArgumentSemantic.Retain)]
        EARestrictedScrollView ScrollView { get; set; }

        // @property (assign, nonatomic) BOOL scrollingEnabled;
        [Export ("scrollingEnabled", ArgumentSemantic.UnsafeUnretained)]
        bool ScrollingEnabled { get; set; }

        // @property (nonatomic, strong) NSArray * pages;
        [Export ("pages", ArgumentSemantic.Retain)]
        NSObject [] Pages { get; set; }

        // -(void)showFullscreen;
        [Export ("showFullscreen")]
        void ShowFullscreen ();

        // -(void)showFullscreenWithAnimateDuration:(CGFloat)duration;
        [Export ("showFullscreenWithAnimateDuration:")]
        void ShowFullscreenWithAnimateDuration (nfloat duration);

        // -(void)showFullscreenWithAnimateDuration:(CGFloat)duration andInitialPageIndex:(NSUInteger)initialPageIndex;
        [Export ("showFullscreenWithAnimateDuration:andInitialPageIndex:")]
        void ShowFullscreenWithAnimateDuration (nfloat duration, nuint initialPageIndex);

        // -(void)showInView:(UIView *)view;
        [Export ("showInView:")]
        void ShowInView (UIView view);

        // -(void)showInView:(UIView *)view animateDuration:(CGFloat)duration;
        [Export ("showInView:animateDuration:")]
        void ShowInView (UIView view, nfloat duration);

        // -(void)showInView:(UIView *)view animateDuration:(CGFloat)duration withInitialPageIndex:(NSUInteger)initialPageIndex;
        [Export ("showInView:animateDuration:withInitialPageIndex:")]
        void ShowInView (UIView view, nfloat duration, nuint initialPageIndex);

        // -(void)hideWithFadeOutDuration:(CGFloat)duration;
        [Export ("hideWithFadeOutDuration:")]
        void HideWithFadeOutDuration (nfloat duration);

        // -(void)setCurrentPageIndex:(NSUInteger)currentPageIndex animated:(BOOL)animated;
        [Export ("setCurrentPageIndex:animated:")]
        void SetCurrentPageIndex (nuint currentPageIndex, bool animated);

        // -(void)limitScrollingToPage:(NSUInteger)lastPageIndex;
        [Export ("limitScrollingToPage:")]
        void LimitScrollingToPage (nuint lastPageIndex);
    }
}
