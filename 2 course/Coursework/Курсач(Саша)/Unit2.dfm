object Form2: TForm2
  Left = 0
  Top = 0
  Caption = 'Form2'
  ClientHeight = 591
  ClientWidth = 560
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 4
    Top = 8
    Width = 46
    Height = 19
    Caption = #1053#1072#1088#1086#1076
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Label2: TLabel
    Left = 4
    Top = 37
    Width = 70
    Height = 19
    Caption = #1055#1088#1072#1079#1076#1085#1080#1082
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Label3: TLabel
    Left = 268
    Top = 66
    Width = 41
    Height = 19
    Caption = #1058#1077#1082#1089#1090
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Label4: TLabel
    Left = 452
    Top = 8
    Width = 36
    Height = 19
    Caption = #1044#1077#1085#1100
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Label5: TLabel
    Left = 292
    Top = 8
    Width = 44
    Height = 19
    Caption = #1052#1077#1089#1103#1094
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -16
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
  end
  object Memo2: TMemo
    Left = 8
    Top = 91
    Width = 544
    Height = 358
    Lines.Strings = (
      'Memo2')
    TabOrder = 10
  end
  object EditDay2: TEdit
    Left = 518
    Top = 12
    Width = 34
    Height = 21
    TabOrder = 13
  end
  object EditMonth2: TEdit
    Left = 367
    Top = 12
    Width = 39
    Height = 21
    TabOrder = 12
  end
  object EditHoliday2: TEdit
    Left = 104
    Top = 37
    Width = 448
    Height = 21
    TabOrder = 11
  end
  object DBLCBPeople: TDBLookupComboBox
    Left = 104
    Top = 8
    Width = 145
    Height = 21
    KeyField = 'Name'
    ListField = 'Name'
    ListSource = DataSource2
    TabOrder = 0
  end
  object Button1: TButton
    Left = 232
    Top = 455
    Width = 113
    Height = 25
    Caption = 'Button1'
    TabOrder = 1
    OnClick = Button1Click
  end
  object DBEdit1: TDBEdit
    Left = 104
    Top = 64
    Width = 25
    Height = 21
    DataField = 'ID_1'
    DataSource = FormMain.DataSource1
    TabOrder = 2
    Visible = False
  end
  object DBEdit2: TDBEdit
    Left = 141
    Top = 64
    Width = 20
    Height = 21
    DataField = 'ID'
    DataSource = FormMain.DataSource1
    TabOrder = 3
    Visible = False
  end
  object DBEdit3: TDBEdit
    Left = 367
    Top = 496
    Width = 121
    Height = 21
    DataField = 'ID'
    DataSource = FormMain.DataSource1
    TabOrder = 4
    Visible = False
  end
  object EditMonth: TDBEdit
    Left = 367
    Top = 11
    Width = 39
    Height = 21
    DataField = 'Month'
    DataSource = FormMain.DataSource1
    TabOrder = 5
  end
  object EditDay: TDBEdit
    Left = 518
    Top = 11
    Width = 34
    Height = 21
    DataField = 'Day'
    DataSource = FormMain.DataSource1
    TabOrder = 6
  end
  object EditHoliday: TDBEdit
    Left = 104
    Top = 37
    Width = 448
    Height = 21
    DataField = 'Name_1'
    DataSource = FormMain.DataSource1
    TabOrder = 7
  end
  object Memo1: TDBMemo
    Left = 8
    Top = 91
    Width = 544
    Height = 358
    DataField = 'Description'
    DataSource = FormMain.DataSource1
    TabOrder = 8
  end
  object DBComboBox1: TDBComboBox
    Left = 104
    Top = 8
    Width = 145
    Height = 21
    DataField = 'Name'
    DataSource = FormMain.DataSource1
    TabOrder = 9
  end
  object SQLQuery1: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT *  FROM Date ORDER BY Month ASC')
    SQLConnection = FormMain.SQLConnection1
    Left = 24
    Top = 486
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 104
    Top = 486
  end
  object ClientDataSet1: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 192
    Top = 486
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    Left = 272
    Top = 486
  end
  object SQLQuery2: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT *  FROM People')
    SQLConnection = FormMain.SQLConnection1
    Left = 24
    Top = 534
  end
  object DataSetProvider2: TDataSetProvider
    DataSet = SQLQuery2
    Left = 104
    Top = 534
  end
  object ClientDataSet2: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider2'
    Left = 192
    Top = 534
  end
  object DataSource2: TDataSource
    DataSet = ClientDataSet2
    Left = 272
    Top = 534
  end
end
