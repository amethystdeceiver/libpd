﻿/*
 * Created by SharpDevelop.
 * User: Tebjan Halm
 * Date: 11.04.2012
 * Time: 11:40
 * 
 * 
 */
using System.Runtime.InteropServices;

namespace LibPDBinding
{
	/// Return Type: void
	///channel: int
	///pitch: int
	///velocity: int
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void t_libpd_noteonhook(int channel, int pitch, int velocity);

	/// Return Type: void
	///channel: int
	///controller: int
	///value: int
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void t_libpd_controlchangehook(int channel, int controller, int value);

	/// Return Type: void
	///channel: int
	///value: int
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void t_libpd_programchangehook(int channel, int value);

	/// Return Type: void
	///channel: int
	///value: int
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void t_libpd_pitchbendhook(int channel, int value);

	/// Return Type: void
	///channel: int
	///value: int
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void t_libpd_aftertouchhook(int channel, int value);

	/// Return Type: void
	///channel: int
	///pitch: int
	///value: int
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void t_libpd_polyaftertouchhook(int channel, int pitch, int value);

	/// Return Type: void
	///port: int
	///param1: int
	///param2: byte
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void t_libpd_midibytehook(int port, int byt);


	public static partial class LibPD
	{
		private static t_libpd_noteonhook noteonHook;
		private static t_libpd_controlchangehook controlchangeHook;
		private static t_libpd_programchangehook programchangeHook;
		private static t_libpd_pitchbendhook pitchbendHook;
		private static t_libpd_aftertouchhook aftertouchHook;
		private static t_libpd_polyaftertouchhook polyaftertouchHook;
		private static t_libpd_midibytehook midibyteHook;
		
		private static void SetupMidi()
		{
			noteonHook = new t_libpd_noteonhook(RaiseNoteOnEvent);
			set_noteonhook(noteonHook);
			
			controlchangeHook = new t_libpd_controlchangehook(RaiseControlChangeEvent);
			set_controlchangehook(controlchangeHook);
			
			programchangeHook = new t_libpd_programchangehook(RaiseProgramChangeEvent);
			set_programchangehook(programchangeHook);
			
			pitchbendHook = new t_libpd_pitchbendhook(RaisePitchbendEvent);
			set_pitchbendhook(pitchbendHook);
			
			aftertouchHook = new t_libpd_aftertouchhook(RaiseAftertouchEvent);
			set_aftertouchhook(aftertouchHook);
			
			polyaftertouchHook = new t_libpd_polyaftertouchhook(RaisePolyAftertouchEvent);
			set_polyaftertouchhook(polyaftertouchHook);
			
			midibyteHook = new t_libpd_midibytehook(RaiseMidiByteEvent);
			set_midibytehook(midibyteHook);
			
		}
		
		public static event t_libpd_noteonhook NoteOn;
		public static event t_libpd_controlchangehook ControlChange;
		public static event t_libpd_programchangehook ProgramChange;
		public static event t_libpd_pitchbendhook Pitchbend;
		public static event t_libpd_aftertouchhook Aftertouch;
		public static event t_libpd_polyaftertouchhook PolyAftertouch;
		public static event t_libpd_midibytehook MidiByte;
		
		private static void RaiseNoteOnEvent(int channel, int pitch, int velocity)
		{
			// Event will be null if there are no subscribers
			if (NoteOn != null)
			{
				// Use the () operator to raise the event.
				NoteOn(channel, pitch, velocity);
			}
		}
		
		private static void RaiseControlChangeEvent(int channel, int controller, int val)
		{
			// Event will be null if there are no subscribers
			if (ControlChange != null)
			{
				// Use the () operator to raise the event.
				ControlChange(channel, controller, val);
			}
		}
		private static void RaiseProgramChangeEvent(int channel, int val)
		{
			// Event will be null if there are no subscribers
			if (ProgramChange != null)
			{
				// Use the () operator to raise the event.
				ProgramChange(channel, val);
			}
		}
		private static void RaisePitchbendEvent(int channel, int val)
		{
			// Event will be null if there are no subscribers
			if (Pitchbend != null)
			{
				// Use the () operator to raise the event.
				Pitchbend(channel, val);
			}
		}
		private static void RaiseAftertouchEvent(int channel, int val)
		{
			// Event will be null if there are no subscribers
			if (Aftertouch != null)
			{
				// Use the () operator to raise the event.
				Aftertouch(channel, val);
			}
		}
		private static void RaisePolyAftertouchEvent(int channel, int pitch, int val)
		{
			// Event will be null if there are no subscribers
			if (PolyAftertouch != null)
			{
				// Use the () operator to raise the event.
				PolyAftertouch(channel, pitch, val);
			}
		}
		private static void RaiseMidiByteEvent(int port, int byt)
		{
			// Event will be null if there are no subscribers
			if (MidiByte != null)
			{
				// Use the () operator to raise the event.
				MidiByte(port, byt);
			}
		}
		
		/// Return Type: int
		///channel: int
		///pitch: int
		///velocity: int
		[DllImport("libpd.dll", EntryPoint="libpd_noteon")]
		public static extern  int noteon(int channel, int pitch, int velocity) ;

		
		/// Return Type: int
		///channel: int
		///controller: int
		///value: int
		[DllImport("libpd.dll", EntryPoint="libpd_controlchange")]
		public static extern  int controlchange(int channel, int controller, int value) ;

		
		/// Return Type: int
		///channel: int
		///value: int
		[DllImport("libpd.dll", EntryPoint="libpd_programchange")]
		public static extern  int programchange(int channel, int value) ;

		
		/// Return Type: int
		///channel: int
		///value: int
		[DllImport("libpd.dll", EntryPoint="libpd_pitchbend")]
		public static extern  int pitchbend(int channel, int value) ;

		
		/// Return Type: int
		///channel: int
		///value: int
		[DllImport("libpd.dll", EntryPoint="libpd_aftertouch")]
		public static extern  int aftertouch(int channel, int value) ;

		
		/// Return Type: int
		///channel: int
		///pitch: int
		///value: int
		[DllImport("libpd.dll", EntryPoint="libpd_polyaftertouch")]
		public static extern  int polyaftertouch(int channel, int pitch, int value) ;

		
		/// Return Type: int
		///port: int
		///param1: int
		///param2: byte
		[DllImport("libpd.dll", EntryPoint="libpd_midibyte")]
		public static extern  int midibyte(int port, int param1, byte param2) ;

		
		/// Return Type: int
		///port: int
		///param1: int
		///param2: byte
		[DllImport("libpd.dll", EntryPoint="libpd_sysex")]
		public static extern  int sysex(int port, int param1, byte param2) ;

		
		/// Return Type: int
		///port: int
		///param1: int
		///param2: byte
		[DllImport("libpd.dll", EntryPoint="libpd_sysrealtime")]
		public static extern  int sysrealtime(int port, int param1, byte param2) ;
		
		/// Return Type: void
		///hook: t_libpd_noteonhook
		[System.Runtime.InteropServices.DllImportAttribute("libpd.dll", EntryPoint="libpd_set_noteonhook")]
		private static extern  void set_noteonhook(t_libpd_noteonhook hook) ;

		
		/// Return Type: void
		///hook: t_libpd_controlchangehook
		[System.Runtime.InteropServices.DllImportAttribute("libpd.dll", EntryPoint="libpd_set_controlchangehook")]
		private static extern  void set_controlchangehook(t_libpd_controlchangehook hook) ;

		
		/// Return Type: void
		///hook: t_libpd_programchangehook
		[System.Runtime.InteropServices.DllImportAttribute("libpd.dll", EntryPoint="libpd_set_programchangehook")]
		private static extern  void set_programchangehook(t_libpd_programchangehook hook) ;

		
		/// Return Type: void
		///hook: t_libpd_pitchbendhook
		[System.Runtime.InteropServices.DllImportAttribute("libpd.dll", EntryPoint="libpd_set_pitchbendhook")]
		private static extern  void set_pitchbendhook(t_libpd_pitchbendhook hook) ;

		
		/// Return Type: void
		///hook: t_libpd_aftertouchhook
		[System.Runtime.InteropServices.DllImportAttribute("libpd.dll", EntryPoint="libpd_set_aftertouchhook")]
		private static extern  void set_aftertouchhook(t_libpd_aftertouchhook hook) ;

		
		/// Return Type: void
		///hook: t_libpd_polyaftertouchhook
		[System.Runtime.InteropServices.DllImportAttribute("libpd.dll", EntryPoint="libpd_set_polyaftertouchhook")]
		private static extern  void set_polyaftertouchhook(t_libpd_polyaftertouchhook hook) ;

		
		/// Return Type: void
		///hook: t_libpd_midibytehook
		[System.Runtime.InteropServices.DllImportAttribute("libpd.dll", EntryPoint="libpd_set_midibytehook")]
		private static extern  void set_midibytehook(t_libpd_midibytehook hook) ;


	}
}
