﻿using System.Linq;
using System.Text.Json.Serialization;
using NStack;
using static Terminal.Gui.Configuration.ConfigurationManager;

namespace Terminal.Gui {

	/// <summary>
	/// The FrameView is a container frame that draws a frame around the contents. It is similar to
	/// a GroupBox in Windows.
	/// </summary>
	public class FrameView : View {

		//internal class FrameViewConfig : Configuration.Config<FrameViewConfig> {

		//	/// <summary>
		//	/// 
		//	/// </summary>
		//	/// 
		//	[JsonConverter (typeof (JsonStringEnumConverter))]
		//	public BorderStyle? DefaultBorderStyle { get; set; }

		//	public override void Apply ()
		//	{
		//		if (DefaultBorderStyle.HasValue) {
		//			FrameView.DefaultBorderStyle = DefaultBorderStyle.Value;
		//		}
		//	}

		//	public override void CopyUpdatedProperitesFrom (FrameViewConfig changedConfig)
		//	{
		//		if (changedConfig.DefaultBorderStyle.HasValue) {
		//			DefaultBorderStyle = changedConfig.DefaultBorderStyle;
		//		}
		//	}

		//	public override void GetHardCodedDefaults ()
		//	{
		//		DefaultBorderStyle = FrameView.DefaultBorderStyle;
		//	}
		//}

		//[Configuration.ConfigProperty]
		//internal static FrameViewConfig Config { get; set; } = new FrameViewConfig ();





		/// <summary>
		/// Initializes a new instance of the <see cref="Gui.FrameView"/> class using <see cref="LayoutStyle.Absolute"/> layout.
		/// </summary>
		/// <param name="frame">Frame.</param>
		/// <param name="title">Title.</param>
		/// <param name="views">Views.</param>
		/// <param name="border">The <see cref="Border"/>.</param>
		public FrameView (Rect frame, ustring title = null, View [] views = null, Border border = null) : base (frame)
		{
			SetInitialProperties (frame, title, views, border);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Gui.FrameView"/> class using <see cref="LayoutStyle.Computed"/> layout.
		/// </summary>
		/// <param name="title">Title.</param>
		/// <param name="border">The <see cref="Border"/>.</param>
		public FrameView (ustring title, Border border = null)
		{
			SetInitialProperties (Rect.Empty, title, null, border);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Gui.FrameView"/> class using <see cref="LayoutStyle.Computed"/> layout.
		/// </summary>
		public FrameView () : this (title: string.Empty) {
			BorderFrame.Thickness = new Thickness (1);
			BorderFrame.BorderStyle = Border.BorderStyle;
			BorderFrame.ColorScheme = ColorScheme;
			BorderFrame.Data = "BorderFrame";
		}

		/// <summary>
		/// The default <see cref="BorderStyle"/> for <see cref="FrameView"/>. The default is <see cref="BorderStyle.Single"/>.
		/// </summary>
		/// <remarks>
		/// This property can be set in a Theme to change the default <see cref="BorderStyle"/> for all <see cref="FrameView"/>s. 
		/// </remarks>
		[SerializableConfigurationProperty (Scope = typeof (ThemeScope)), JsonConverter (typeof (JsonStringEnumConverter))]
		public static BorderStyle DefaultBorderStyle { get; set; } = BorderStyle.Single;

		void SetInitialProperties (Rect frame, ustring title, View [] views = null, Border border = null)
		{
			this.Title = title;
			if (border == null) {
				Border = new Border () {
					BorderStyle = DefaultBorderStyle,
					//Title = title
				};
			} else {
				Border = border;
				//if (ustring.IsNullOrEmpty (border.Title)) {
				//	border.Title = title;
				//}
			}
		}

		public override void BeginInit ()
		{
			base.BeginInit ();


		}

		///<inheritdoc/>
		public override bool OnEnter (View view)
		{
			if (Subviews.Count == 0 || !Subviews.Any (subview => subview.CanFocus)) {
				Application.Driver?.SetCursorVisibility (CursorVisibility.Invisible);
			}

			return base.OnEnter (view);
		}
	}
}
