/*
 *  Copyright (C) 2002 Urban Science Applications, Inc. 
 *
 *  This library is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU Lesser General Public
 *  License as published by the Free Software Foundation; either
 *  version 2.1 of the License, or (at your option) any later version.
 *
 *  This library is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *  Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with this library; if not, write to the Free Software
 *  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 *
 */


#region Using
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
#endregion

namespace Geotools.IO
{
	/// <summary>
	/// This class aids in the writing of Dbase IV files. 
	/// </summary>
	/// <remarks>
	/// Attribute information of an ESRI Shapefile is written using Dbase IV files.
	/// </remarks>
	public class DbaseFileWriter : IDisposable
	{
		private string _filename;
		private BinaryWriter _writer;
		private bool _headerWritten = false;
		private DbaseFileHeader _header;
		private int _recordCount = 0;
		private bool _disposed = false;

		/// <summary>
		/// Initializes a new instance of the DbaseFileWriter class.
		/// </summary>
		public DbaseFileWriter(string filename)
		{
			if (filename == null)
			{
				throw new ArgumentNullException("filename");
			}

			_filename = filename;
			_writer = new BinaryWriter(File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.None));
			_header = new DbaseFileHeader();
		}

		private void WriteHeader()
		{
			// Go back to the start of the stream
			_writer.Seek(0, SeekOrigin.Begin);
			_header.SetNumRecords(_recordCount);
			_header.WriteHeader(_writer);
			_headerWritten = true;
		}

		public void AddColumn(DbaseFieldDescriptor field)
		{
			this.AddColumn(field.Name, field.DbaseType, field.Length, field.DecimalCount);
		}

		public void AddColumn(string name, char dbaseType, int length, int decimalCount)
		{
			if (!_headerWritten)
			{
				_header.AddColumn(name, dbaseType, length, decimalCount);
			}
			else
			{
				throw new InvalidOperationException("Cannot add columns after performing write operation.");
			}
		}

		public void RemoveColumn(string fieldName)
		{
			if (!_headerWritten)
			{
				_header.RemoveColumn(fieldName);
			}
			else
			{
				throw new InvalidOperationException("Cannot add columns after performing write operation.");
			}
		}

		public void Write(ArrayList columnValues)
		{
			this.EnsureHeader();

			if (columnValues == null)
			{
				throw new ArgumentNullException("columnValues");
			}

			_writer.Write((byte)0x20); // the deleted flag

			for (int i = 0; i < columnValues.Count; i++)
			{
				if ((columnValues[i] == System.DBNull.Value) && (_header.Fields[i].DbaseType == 'C'))
				{
					// Force null value to blank string
					columnValues[i] = "";
				}

				if ((columnValues[i] is double) || (columnValues[i] is int))
				{
					Write(Convert.ToDouble(columnValues[i]), _header.Fields[i].Length, _header.Fields[i].DecimalCount);
				}
				else if (columnValues[i] is float)
				{
					Write(Convert.ToSingle(columnValues[i]),  _header.Fields[i].Length, _header.Fields[i].DecimalCount);
				}
				else if (columnValues[i] is bool)
				{
					Write((bool)columnValues[i]);
				}
				else if (columnValues[i] is string)
				{
					int length = _header.Fields[i].Length;
					Write((string)columnValues[i], length);
				}
				else if (columnValues[i] is DateTime)
				{
					Write((DateTime)columnValues[i]);
				}
				else
				{
					throw new NotSupportedException("Unsupported data type.");
				}
			}

			_recordCount++;
		}

		private void Write(double number, int length, int decimalCount)
		{
			this.EnsureHeader();

			// write with 19 chars.
			string format="{0:";
			for(int i=0; i<decimalCount;i++)
			{
				if (i==0)
				{
					format=format+"0.";
				}
				format=format+"0";
			}
			format=format+"}";
			string str = String.Format(format,number);
			for (int i=0; i< length-str.Length; i++)
			{
				_writer.Write((byte)0x20);
			}
			//_writer.Write(str);
			//_writer.Write((byte)0x20);
			foreach(char c in str)
			{
				_writer.Write(c);
			}
		}

		private void Write(float number, int length, int decimalCount)
		{
			this.EnsureHeader();

			string formatString = "{0:#.";

			for (int i = 0; i < decimalCount; i++)
			{
				formatString += "0";
			}

			_writer.Write(String.Format(formatString, number));
		}

		private void Write(string text, int length)
		{
			this.EnsureHeader();

			// ensure string is not too big
			text = text.PadRight(length,' ');
			string dbaseString = text.Substring(0,length);

			// will extra chars get written??
			//_writer.Write(dbaseString);
			foreach(char c in dbaseString)
			{
				_writer.Write(c);
			}

			int extraPadding = length - dbaseString.Length;
			for(int i=0; i < extraPadding; i++)
			{
				_writer.Write((byte)0x20);
			}
		}

		private void Write(DateTime date)
		{
			this.EnsureHeader();

			_writer.Write(date.Year-1900);
			_writer.Write(date.Month);
			_writer.Write(date.Day);

			_recordCount++;
		}

		private void Write(bool flag)
		{
			this.EnsureHeader();

			if (flag)
			{
				_writer.Write("T");
			}
			else 
			{
				_writer.Write("F");
			}
		}

		public void Flush()
		{
			_writer.Flush();
		}

		public void Close()
		{
			// Write header
			this.WriteHeader();
			_writer.Close();
		}

		private void EnsureHeader()
		{
			if (!_headerWritten)
			{
				this.WriteHeader();
			}
		}

		#region IDisposable Members

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					this.Close();
				}
			}

			_disposed = true;
		}

		#endregion
	}
}
