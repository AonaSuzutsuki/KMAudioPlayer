﻿'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.1
'
'     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
'     コードが再生成されるときに損失したりします。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'このクラスは StronglyTypedResourceBuilder クラスが ResGen
    'または Visual Studio のようなツールを使用して自動生成されました。
    'メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    'ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    '''<summary>
    '''  ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("KMMediaPlayer_Fix.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        '''  現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        Friend ReadOnly Property artwork() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("artwork", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property Back() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Back", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property BackHover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("BackHover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property down() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("down", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property ForwardHover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("ForwardHover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property Go() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Go", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property PauseHover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("PauseHover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property PlayHover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("PlayHover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property StopHover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("StopHover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property StopPush() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("StopPush", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property up() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("up", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property VolumeHover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("VolumeHover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace
