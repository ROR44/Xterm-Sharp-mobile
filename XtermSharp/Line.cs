﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace XtermSharp {
	/// <summary>
	/// Gets a line of text that consists of one or more fragments
	/// </summary>
	[DebuggerDisplay ("{DebuggerDisplay}")]
	public class Line {
		readonly List<LineFragment> fragments;

		public Line ()
		{
			fragments = new List<LineFragment> ();
		}

		/// <summary>
		/// Gets the length of the line
		/// </summary>
		public int Length { get; private set; }

		string DebuggerDisplay {
			get {
				if (fragments.Count < 1) {
					return "[]";
				}

				var sb = new StringBuilder ();
				sb.Append ($"{fragments.Count}/{Length} : [");
				for (int i = 0; i < fragments.Count; i++) {
					if (fragments [i].Text == "\n") {
						sb.Append ("\\n");
					} else {
						sb.Append (fragments [i].Text);
					}

					if (i < fragments.Count - 1)
						sb.Append ("][");
				}
				sb.Append ("]");

				return sb.ToString ();
			}
		}

		public void Add (LineFragment fragment)
		{
			fragments.Add (fragment);

			Length += fragment.Length;
		}

		public void GetFragmentStrings (StringBuilder builder)
		{
			foreach (var fragment in fragments) {
				builder.Append (fragment.Text);
			}
		}

		public override string ToString ()
		{
			var sb = new StringBuilder ();
			foreach (var fragment in fragments) {
				sb.Append (fragment.Text);
			}

			return sb.ToString ();
		}
	}
}
