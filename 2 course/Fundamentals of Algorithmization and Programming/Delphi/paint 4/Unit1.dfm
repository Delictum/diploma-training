object Form1: TForm1
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  Caption = #1051#1072#1073#1072' 4'
  ClientHeight = 423
  ClientWidth = 516
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label4: TLabel
    Left = 144
    Top = 400
    Width = 3
    Height = 13
  end
  object PageControl1: TPageControl
    Left = 8
    Top = 8
    Width = 500
    Height = 386
    ActivePage = TabSheet4
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = #1050#1072#1083#1077#1085#1076#1072#1088#1100
      object Label1: TLabel
        Left = 152
        Top = 200
        Width = 96
        Height = 32
        Caption = 'Label1'
        Font.Charset = RUSSIAN_CHARSET
        Font.Color = clWindowText
        Font.Height = -24
        Font.Name = 'Fixedsys'
        Font.Style = []
        ParentFont = False
      end
      object MonthCalendar1: TMonthCalendar
        Left = 136
        Top = 19
        Width = 191
        Height = 160
        Date = 42780.663014641210000000
        TabOrder = 0
        OnClick = MonthCalendar1Click
      end
    end
    object TabSheet2: TTabSheet
      Caption = #1055#1083#1077#1077#1077#1077#1088
      ImageIndex = 1
      object MediaPlayer1: TMediaPlayer
        Left = 152
        Top = 256
        Width = 253
        Height = 30
        DoubleBuffered = True
        Display = Panel1
        ParentDoubleBuffered = False
        TabOrder = 0
      end
      object Button1: TButton
        Left = 48
        Top = 259
        Width = 75
        Height = 25
        Caption = #1054#1090#1082#1088#1099#1090#1100
        TabOrder = 1
        OnClick = Button1Click
      end
      object Panel1: TPanel
        Left = 16
        Top = 3
        Width = 457
        Height = 247
        TabOrder = 2
      end
    end
    object TabSheet3: TTabSheet
      Caption = 'Timer'
      ImageIndex = 2
      object Label2: TLabel
        Left = 132
        Top = 216
        Width = 187
        Height = 19
        Caption = #1047#1072#1082#1088#1099#1090#1100' '#1087#1088#1080#1083#1086#1078#1077#1085#1080#1077' '#1095#1077#1088#1077#1079':'
        Font.Charset = RUSSIAN_CHARSET
        Font.Color = clWindowText
        Font.Height = -16
        Font.Name = 'Times New Roman'
        Font.Style = []
        ParentFont = False
      end
      object Label3: TLabel
        Left = 281
        Top = 259
        Width = 38
        Height = 13
        Caption = #1057#1077#1082#1091#1085#1076
      end
      object Label5: TLabel
        Left = 92
        Top = 24
        Width = 332
        Height = 22
        Caption = #1042#1074#1077#1076#1080#1090#1077' '#1082#1083#1102#1095' '#1076#1083#1103' '#1086#1089#1090#1072#1085#1086#1074#1082#1080' '#1090#1072#1081#1084#1077#1088#1072
        Font.Charset = RUSSIAN_CHARSET
        Font.Color = clWindowText
        Font.Height = -19
        Font.Name = 'Times New Roman'
        Font.Style = [fsBold]
        ParentFont = False
        Visible = False
      end
      object Label6: TLabel
        Left = 312
        Top = 67
        Width = 58
        Height = 13
        Caption = #1055#1086#1087#1099#1090#1082#1080': 3'
        Visible = False
      end
      object Button3: TButton
        Left = 176
        Top = 304
        Width = 75
        Height = 25
        Caption = #1055#1088#1080#1084#1077#1085#1080#1090#1100
        TabOrder = 0
        OnClick = Button3Click
      end
      object Edit1: TEdit
        Left = 154
        Top = 256
        Width = 121
        Height = 21
        NumbersOnly = True
        TabOrder = 1
      end
      object Edit2: TEdit
        Left = 154
        Top = 64
        Width = 121
        Height = 21
        TabOrder = 2
        Visible = False
      end
      object Button2: TButton
        Left = 176
        Top = 112
        Width = 75
        Height = 25
        Caption = 'STOP'
        TabOrder = 3
        Visible = False
        OnClick = Button2Click
      end
    end
    object TabSheet4: TTabSheet
      Caption = 'Paint'
      ImageIndex = 3
      ExplicitLeft = 0
      ExplicitTop = 28
      object GroupBox1: TGroupBox
        Left = 3
        Top = 48
        Width = 486
        Height = 307
        TabOrder = 0
        object Image1: TImage
          Left = 3
          Top = 3
          Width = 480
          Height = 346
          Cursor = crUpArrow
          OnMouseDown = Image1MouseDown
          OnMouseMove = Image1MouseMove
          OnMouseUp = Image1MouseUp
        end
      end
      object Button4: TButton
        Left = 3
        Top = 10
        Width = 70
        Height = 25
        Caption = 'Speed save'
        TabOrder = 1
        OnClick = Button4Click
      end
      object Button5: TButton
        Left = 207
        Top = 10
        Width = 41
        Height = 25
        Caption = 'New'
        Font.Charset = RUSSIAN_CHARSET
        Font.Color = clLime
        Font.Height = -11
        Font.Name = 'Times New Roman'
        Font.Style = [fsBold]
        ParentFont = False
        TabOrder = 2
        OnClick = Button5Click
      end
      object Button6: TButton
        Left = 86
        Top = 10
        Width = 49
        Height = 25
        Caption = 'Save'
        TabOrder = 3
        OnClick = Button6Click
      end
      object Button7: TButton
        Left = 147
        Top = 10
        Width = 46
        Height = 25
        Caption = 'Open'
        TabOrder = 4
        OnClick = Button7Click
      end
    end
  end
  object OpenDialog1: TOpenDialog
    Left = 460
    Top = 384
  end
  object Timer1: TTimer
    Enabled = False
    OnTimer = Timer1Timer
    Left = 100
    Top = 392
  end
  object Timer2: TTimer
    Enabled = False
    Interval = 2000
    OnTimer = Timer2Timer
    Left = 396
    Top = 392
  end
  object SaveDialog1: TSaveDialog
    DefaultExt = '*.jpg'
    Filter = 'JPG|*.jpg'
    Left = 156
    Top = 376
  end
  object OpenDialog2: TOpenDialog
    Filter = 'jpg|*.jpg'
    Left = 319
    Top = 272
  end
end
