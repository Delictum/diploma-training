object Form1: TForm1
  Left = 0
  Top = 0
  Caption = #1050#1072#1083#1086#1088#1080#1080
  ClientHeight = 678
  ClientWidth = 1090
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
    Left = 553
    Top = 11
    Width = 225
    Height = 13
    Caption = #1055#1086#1080#1089#1082' '#1087#1086#1082#1091#1087#1082#1080' '#1080' '#1087#1088#1086#1076#1072#1078#1080' '#1087#1086' '#1087#1091#1085#1082#1090#1091' '#1086#1073#1084#1077#1085#1072
  end
  object Label2: TLabel
    Left = 553
    Top = 59
    Width = 30
    Height = 13
    Caption = #1055#1086#1080#1089#1082
  end
  object DBGrid1: TDBGrid
    Left = 8
    Top = 8
    Width = 529
    Height = 273
    DataSource = DataSource1
    ReadOnly = True
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'id'
        Visible = False
      end
      item
        Expanded = False
        FieldName = 'Name'
        Width = 200
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Name_1'
        Width = 220
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Calorie'
        Visible = True
      end>
  end
  object Edit1: TEdit
    Left = 167
    Top = 287
    Width = 282
    Height = 21
    TabOrder = 1
  end
  object Edit2: TEdit
    Left = 455
    Top = 287
    Width = 82
    Height = 21
    TabOrder = 2
  end
  object Button1: TButton
    Left = 136
    Top = 314
    Width = 89
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    TabOrder = 3
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 231
    Top = 314
    Width = 90
    Height = 25
    Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 4
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 327
    Top = 314
    Width = 89
    Height = 25
    Caption = #1059#1076#1072#1083#1080#1090#1100
    TabOrder = 5
    OnClick = Button3Click
  end
  object DBEdit1: TDBEdit
    Left = 72
    Top = 640
    Width = 33
    Height = 21
    DataField = 'id'
    DataSource = DataSource1
    TabOrder = 6
    Visible = False
  end
  object Button4: TButton
    Left = 1007
    Top = 28
    Width = 75
    Height = 25
    Caption = 'Locate'
    TabOrder = 7
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 553
    Top = 28
    Width = 75
    Height = 25
    Caption = 'Lookup'
    TabOrder = 8
    OnClick = Button5Click
  end
  object Button6: TButton
    Left = 776
    Top = 160
    Width = 66
    Height = 25
    Caption = 'Excel'
    TabOrder = 9
    OnClick = Button6Click
  end
  object Edit4: TEdit
    Left = 634
    Top = 30
    Width = 177
    Height = 21
    TabOrder = 10
  end
  object Edit5: TEdit
    Left = 824
    Top = 30
    Width = 177
    Height = 21
    TabOrder = 11
  end
  object DBLookupListBox1: TDBLookupListBox
    Left = 553
    Top = 91
    Width = 132
    Height = 134
    KeyField = 'Name'
    ListField = 'Name'
    ListSource = DataSource2
    TabOrder = 12
  end
  object Edit6: TEdit
    Left = 589
    Top = 56
    Width = 492
    Height = 21
    TabOrder = 13
    OnKeyPress = Edit6KeyPress
  end
  object DBGrid2: TDBGrid
    Left = 937
    Top = 91
    Width = 144
    Height = 134
    DataSource = DataSource4
    TabOrder = 14
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'name'
        Visible = True
      end>
  end
  object Panel1: TPanel
    Left = 817
    Top = 11
    Width = 1
    Height = 42
    Caption = 'Panel1'
    TabOrder = 15
  end
  object DBNavigator1: TDBNavigator
    Left = 691
    Top = 91
    Width = 240
    Height = 25
    TabOrder = 16
  end
  object Button7: TButton
    Left = 776
    Top = 129
    Width = 66
    Height = 25
    Caption = 'Refresh'
    TabOrder = 17
    OnClick = Button7Click
  end
  object Button8: TButton
    Left = 776
    Top = 191
    Width = 66
    Height = 25
    Caption = 'HeaderExcel'
    TabOrder = 18
    OnClick = Button8Click
  end
  object DBChart1: TDBChart
    Left = 8
    Top = 345
    Width = 1074
    Height = 332
    Title.Text.Strings = (
      'TDBChart')
    TabOrder = 19
    DefaultCanvas = 'TGDIPlusCanvas'
    ColorPaletteIndex = 13
    object Series1: TBarSeries
      DataSource = SQLQuery3
      XLabelsSource = 'Name_1'
      XValues.Name = 'X'
      XValues.Order = loAscending
      XValues.ValueSource = 'id'
      YValues.Name = 'Bar'
      YValues.Order = loNone
      YValues.ValueSource = 'Calorie'
    end
  end
  object DBGrid3: TDBGrid
    Left = 832
    Top = 231
    Width = 249
    Height = 108
    DataSource = DataSource5
    TabOrder = 20
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = #1055#1086#1082#1091#1087#1082#1072
        Visible = True
      end
      item
        Expanded = False
        FieldName = #1055#1088#1086#1076#1072#1078#1072
        Visible = True
      end
      item
        Expanded = False
        FieldName = #1053#1072#1080#1084#1077#1085#1086#1074#1072#1085#1080#1077
        Visible = True
      end>
  end
  object DBGrid4: TDBGrid
    Left = 553
    Top = 231
    Width = 132
    Height = 108
    DataSource = DataSource6
    TabOrder = 21
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'calorie'
        Visible = True
      end>
  end
  object DBLookupComboBox1: TDBLookupComboBox
    Left = 8
    Top = 287
    Width = 153
    Height = 21
    KeyField = 'Name'
    ListField = 'Name'
    ListSource = DataSource2
    TabOrder = 22
  end
  object SQLConnection1: TSQLConnection
    ConnectionName = 'MySQLConnection'
    DriverName = 'MySQL'
    LoginPrompt = False
    Params.Strings = (
      'DriverUnit=Data.DBXMySQL'
      
        'DriverPackageLoader=TDBXDynalinkDriverLoader,DbxCommonDriver250.' +
        'bpl'
      
        'DriverAssemblyLoader=Borland.Data.TDBXDynalinkDriverLoader,Borla' +
        'nd.Data.DbxCommonDriver,Version=24.0.0.0,Culture=neutral,PublicK' +
        'eyToken=91d62ebb5b0d1b1b'
      
        'MetaDataPackageLoader=TDBXMySqlMetaDataCommandFactory,DbxMySQLDr' +
        'iver250.bpl'
      
        'MetaDataAssemblyLoader=Borland.Data.TDBXMySqlMetaDataCommandFact' +
        'ory,Borland.Data.DbxMySQLDriver,Version=24.0.0.0,Culture=neutral' +
        ',PublicKeyToken=91d62ebb5b0d1b1b'
      'GetDriverFunc=getSQLDriverMYSQL'
      'LibraryName=dbxmys.dll'
      'LibraryNameOsx=libsqlmys.dylib'
      'VendorLib=LIBMYSQL.dll'
      'VendorLibWin64=libmysql.dll'
      'VendorLibOsx=libmysqlclient.dylib'
      'MaxBlobSize=-1'
      'DriverName=MySQL'
      'HostName=127.0.0.1'
      'Database=kol'
      'User_Name=mysql'
      'Password=mysql'
      'ServerCharSet=cp1251'
      'BlobSize=-1'
      'ErrorResourceFile='
      'LocaleCode=0000'
      'Compressed=False'
      'Encrypted=False'
      'ConnectTimeout=60')
    Connected = True
    Left = 72
    Top = 584
  end
  object SQLQuery2: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT Name  FROM productGroup')
    SQLConnection = SQLConnection1
    Left = 168
    Top = 632
  end
  object DataSetProvider2: TDataSetProvider
    DataSet = SQLQuery2
    Left = 256
    Top = 632
  end
  object ClientDataSet2: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider2'
    Left = 344
    Top = 632
  end
  object DataSource2: TDataSource
    DataSet = ClientDataSet2
    Left = 424
    Top = 632
  end
  object OpenDialog1: TOpenDialog
    Left = 488
    Top = 632
  end
  object SQLQuery1: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      
        'SELECT calories.id, productGroup.Name, calories.Name, Calorie FR' +
        'OM productGroup, calories WHERE productGroup.Id = calories.Group' +
        'sId')
    SQLConnection = SQLConnection1
    Left = 168
    Top = 584
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 344
    Top = 584
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 256
    Top = 584
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    OnDataChange = DataSource1DataChange
    Left = 424
    Top = 584
  end
  object DataSource3: TDataSource
    DataSet = ClientDataSet3
    OnDataChange = DataSource1DataChange
    Left = 864
    Top = 584
  end
  object ClientDataSet3: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider3'
    Left = 784
    Top = 584
  end
  object DataSetProvider3: TDataSetProvider
    DataSet = SQLQuery3
    Left = 696
    Top = 584
  end
  object SQLQuery3: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      
        'SELECT calories.id, productGroup.Name, calories.Name, Calorie FR' +
        'OM productGroup, calories WHERE productGroup.Id = calories.Group' +
        'sId')
    SQLConnection = SQLConnection1
    Left = 608
    Top = 584
  end
  object MySQLDatabase1: TMySQLDatabase
    Connected = True
    DatabaseName = 'kol'
    UserName = 'mysql'
    UserPassword = 'mysql'
    Host = '127.0.0.1'
    ConnectOptions = [coCompress]
    ConnectionCharacterSet = 'cp1251'
    Params.Strings = (
      'Port=3306'
      'TIMEOUT=30'
      'DatabaseName=kol'
      'UID=mysql'
      'PWD=mysql'
      'Host=127.0.0.1')
    DatasetOptions = []
    Left = 584
    Top = 288
  end
  object MySQLQuery1: TMySQLQuery
    Database = MySQLDatabase1
    Active = True
    SQL.Strings = (
      'SELECT name  FROM productgroup')
    Left = 672
    Top = 288
  end
  object DataSource4: TDataSource
    DataSet = MySQLQuery1
    Left = 752
    Top = 288
  end
  object ADOConnection1: TADOConnection
    Connected = True
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\25 Information T' +
      'echnology Software\4 course\Data base\18.mdb;Persist Security In' +
      'fo=False'
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 584
    Top = 240
  end
  object ADOQuery1: TADOQuery
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      
        'SELECT ['#1050#1091#1088#1089' '#1086#1073#1084#1077#1085#1072'].'#1055#1086#1082#1091#1087#1082#1072', ['#1050#1091#1088#1089' '#1086#1073#1084#1077#1085#1072'].'#1055#1088#1086#1076#1072#1078#1072', '#1043#1086#1088#1086#1076#1072'.'#1053#1072#1080#1084 +
        #1077#1085#1086#1074#1072#1085#1080#1077
      
        'FROM '#1043#1086#1088#1086#1076#1072' INNER JOIN ['#1050#1091#1088#1089' '#1086#1073#1084#1077#1085#1072'] ON '#1043#1086#1088#1086#1076#1072'.['#1050#1086#1076'_'#1075#1086#1088#1086#1076#1072'] = ['#1050 +
        #1091#1088#1089' '#1086#1073#1084#1077#1085#1072'].['#1050#1086#1076'_'#1075#1086#1088#1086#1076#1072']'
      'WHERE ((('#1043#1086#1088#1086#1076#1072'.'#1053#1072#1080#1084#1077#1085#1086#1074#1072#1085#1080#1077')="'#1052#1080#1085#1089#1082'"));')
    Left = 672
    Top = 240
  end
  object DataSource5: TDataSource
    DataSet = ADOQuery1
    Left = 752
    Top = 240
  end
  object FDConnection1: TFDConnection
    Params.Strings = (
      'Database=kol'
      'User_Name=mysql'
      'Password=mysql'
      'Server=127.0.0.1'
      'DriverID=MySQL')
    Connected = True
    LoginPrompt = False
    Left = 296
    Top = 224
  end
  object FDQuery1: TFDQuery
    Active = True
    Connection = FDConnection1
    SQL.Strings = (
      'SELECT calorie  FROM Calories')
    Left = 384
    Top = 224
  end
  object DataSource6: TDataSource
    DataSet = FDQuery1
    Left = 464
    Top = 224
  end
end
