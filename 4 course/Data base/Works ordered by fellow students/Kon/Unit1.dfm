object Form1: TForm1
  Left = 0
  Top = 0
  ActiveControl = PageControl1
  Caption = 'Restourant'
  ClientHeight = 683
  ClientWidth = 1102
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
  object PageControl1: TPageControl
    Left = 0
    Top = 0
    Width = 809
    Height = 345
    ActivePage = TabSheet1
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = 'Menu'
      ExplicitWidth = 613
      object Label2: TLabel
        Left = 27
        Top = 288
        Width = 30
        Height = 13
        Caption = #1055#1086#1080#1089#1082
      end
      object DBGrid1: TDBGrid
        Left = 0
        Top = 0
        Width = 789
        Height = 201
        DataSource = DataSource1
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
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'date'
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'Name'
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'Type'
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'cost'
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'count'
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'VAT'
            Visible = True
          end>
      end
      object Button1: TButton
        Left = 528
        Top = 258
        Width = 75
        Height = 25
        Caption = #1044#1086#1073#1072#1074#1083#1077#1085#1080#1077
        TabOrder = 1
        OnClick = Button1Click
      end
      object Button2: TButton
        Left = 609
        Top = 258
        Width = 99
        Height = 25
        Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1086#1074#1072#1085#1080#1077
        TabOrder = 2
        OnClick = Button2Click
      end
      object Button3: TButton
        Left = 714
        Top = 258
        Width = 75
        Height = 25
        Caption = #1059#1076#1072#1083#1077#1085#1080#1077
        TabOrder = 3
        OnClick = Button3Click
      end
      object DBNavigator1: TDBNavigator
        Left = 528
        Top = 289
        Width = 260
        Height = 25
        DataSource = DataSource1
        TabOrder = 4
      end
      object Edit3: TEdit
        Left = 463
        Top = 207
        Width = 82
        Height = 21
        TabOrder = 5
      end
      object Edit2: TEdit
        Left = 375
        Top = 207
        Width = 82
        Height = 21
        TabOrder = 6
      end
      object DBLookupComboBox1: TDBLookupComboBox
        Left = 0
        Top = 207
        Width = 128
        Height = 21
        KeyField = 'Name'
        ListField = 'Name'
        ListSource = DataSource2
        TabOrder = 7
      end
      object DBLookupComboBox2: TDBLookupComboBox
        Left = 134
        Top = 207
        Width = 128
        Height = 21
        KeyField = 'Type'
        ListField = 'Type'
        ListSource = DataSource3
        TabOrder = 8
      end
      object Button5: TButton
        Left = 0
        Top = 234
        Width = 75
        Height = 21
        Caption = 'Lookup'
        TabOrder = 9
        OnClick = Button5Click
      end
      object Edit4: TEdit
        Left = 81
        Top = 234
        Width = 177
        Height = 21
        TabOrder = 10
      end
      object Edit6: TEdit
        Left = 81
        Top = 288
        Width = 177
        Height = 21
        TabOrder = 11
        OnKeyPress = Edit6KeyPress
      end
      object Edit5: TEdit
        Left = 81
        Top = 261
        Width = 177
        Height = 21
        TabOrder = 12
      end
      object Button4: TButton
        Left = 0
        Top = 261
        Width = 75
        Height = 21
        Caption = 'Locate'
        TabOrder = 13
        OnClick = Button4Click
      end
      object Button6: TButton
        Left = 287
        Top = 234
        Width = 66
        Height = 25
        Caption = 'Excel'
        TabOrder = 14
        OnClick = Button6Click
      end
      object DateTimePicker1: TDateTimePicker
        Left = 268
        Top = 207
        Width = 101
        Height = 21
        Date = 43476.566383761570000000
        Time = 43476.566383761570000000
        TabOrder = 15
      end
      object Button8: TButton
        Left = 287
        Top = 265
        Width = 66
        Height = 25
        Caption = 'HeaderExcel'
        TabOrder = 16
        OnClick = Button8Click
      end
    end
    object TabSheet2: TTabSheet
      Caption = 'Dish name'
      ImageIndex = 1
      ExplicitWidth = 609
      object DBGrid2: TDBGrid
        Left = 3
        Top = 0
        Width = 449
        Height = 185
        DataSource = DataSource2
        TabOrder = 0
        TitleFont.Charset = DEFAULT_CHARSET
        TitleFont.Color = clWindowText
        TitleFont.Height = -11
        TitleFont.Name = 'Tahoma'
        TitleFont.Style = []
        Columns = <
          item
            Expanded = False
            FieldName = 'Id'
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'Name'
            Visible = True
          end>
      end
    end
    object TabSheet3: TTabSheet
      Caption = 'Dish type'
      ImageIndex = 2
      ExplicitWidth = 609
      object DBGrid3: TDBGrid
        Left = 0
        Top = 3
        Width = 433
        Height = 206
        DataSource = DataSource3
        TabOrder = 0
        TitleFont.Charset = DEFAULT_CHARSET
        TitleFont.Color = clWindowText
        TitleFont.Height = -11
        TitleFont.Name = 'Tahoma'
        TitleFont.Style = []
        Columns = <
          item
            Expanded = False
            FieldName = 'Id'
            Visible = True
          end
          item
            Expanded = False
            FieldName = 'Type'
            Visible = True
          end>
      end
    end
  end
  object DBLookupListBox1: TDBLookupListBox
    Left = 0
    Top = 351
    Width = 132
    Height = 134
    KeyField = 'Name'
    ListField = 'Name'
    ListSource = DataSource2
    TabOrder = 1
  end
  object DBEdit1: TDBEdit
    Left = 0
    Top = 491
    Width = 121
    Height = 21
    DataField = 'id'
    DataSource = DataSource1
    TabOrder = 2
    Visible = False
  end
  object DBChart1: TDBChart
    Left = 138
    Top = 351
    Width = 662
    Height = 285
    Title.Text.Strings = (
      'TDBChart')
    TabOrder = 3
    DefaultCanvas = 'TGDIPlusCanvas'
    ColorPaletteIndex = 13
    object Series1: TBarSeries
      DataSource = MySQLQuery4
      XValues.Name = 'X'
      XValues.Order = loAscending
      XValues.ValueSource = 'id'
      YValues.Name = 'Bar'
      YValues.Order = loNone
      YValues.ValueSource = 'cost'
    end
  end
  object DBGrid4: TDBGrid
    Left = 953
    Top = 24
    Width = 144
    Height = 134
    DataSource = DataSource5
    TabOrder = 4
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
  object DBGrid5: TDBGrid
    Left = 815
    Top = 175
    Width = 282
    Height = 108
    DataSource = DataSource7
    TabOrder = 5
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'id'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'date'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Name'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Type'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'cost'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'count'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'VAT'
        Visible = True
      end>
  end
  object DBGrid6: TDBGrid
    Left = 815
    Top = 24
    Width = 132
    Height = 134
    DataSource = DataSource6
    TabOrder = 6
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'Id'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Name'
        Visible = True
      end>
  end
  object Button7: TButton
    Left = 291
    Top = 320
    Width = 66
    Height = 25
    Caption = 'Refresh'
    TabOrder = 7
    OnClick = Button7Click
  end
  object MySQLDatabase1: TMySQLDatabase
    Connected = True
    DatabaseName = 'restaurantmenu'
    UserName = 'mysql'
    UserPassword = 'mysql'
    Host = '127.0.0.1'
    ConnectOptions = [coCompress]
    Params.Strings = (
      'Port=3306'
      'TIMEOUT=30'
      'DatabaseName=restaurantmenu'
      'Host=127.0.0.1'
      'UID=mysql'
      'PWD=mysql')
    ReadOnly = True
    DatasetOptions = []
    Left = 320
    Top = 432
  end
  object MySQLQuery1: TMySQLQuery
    Database = MySQLDatabase1
    Active = True
    SQL.Strings = (
      
        'SELECT menu.id, date, namedish.Name, typedish.Type, cost, count,' +
        ' VAT FROM menu, namedish, typedish  WHERE namedish.Id = menu.Nam' +
        'eDishId AND typedish.Id = menu.TypeDishId')
    Left = 400
    Top = 376
  end
  object MySQLQuery2: TMySQLQuery
    Database = MySQLDatabase1
    Active = True
    SQL.Strings = (
      'SELECT * FROM namedish')
    Left = 472
    Top = 376
  end
  object MySQLQuery3: TMySQLQuery
    Database = MySQLDatabase1
    Active = True
    SQL.Strings = (
      'SELECT * FROM typedish')
    Left = 544
    Top = 376
  end
  object DataSource1: TDataSource
    DataSet = MySQLQuery1
    OnDataChange = DataSource1DataChange
    Left = 160
    Top = 376
  end
  object DataSource2: TDataSource
    DataSet = MySQLQuery2
    Left = 232
    Top = 376
  end
  object DataSource3: TDataSource
    DataSet = MySQLQuery3
    Left = 312
    Top = 376
  end
  object OpenDialog1: TOpenDialog
    Left = 400
    Top = 432
  end
  object MySQLQuery4: TMySQLQuery
    Database = MySQLDatabase1
    Active = True
    SQL.Strings = (
      
        'SELECT menu.id, date, namedish.Name, typedish.Type, cost, count,' +
        ' VAT FROM menu, namedish, typedish  WHERE namedish.Id = menu.Nam' +
        'eDishId AND typedish.Id = menu.TypeDishId')
    Left = 616
    Top = 376
  end
  object DataSource4: TDataSource
    DataSet = MySQLQuery4
    Left = 160
    Top = 432
  end
  object DataSource6: TDataSource
    DataSet = FDQuery1
    Left = 1040
    Top = 505
  end
  object FDConnection1: TFDConnection
    Params.Strings = (
      'Database=restaurantmenu'
      'User_Name=mysql'
      'Password=mysql'
      'Server=127.0.0.1'
      'DriverID=MySQL')
    Connected = True
    LoginPrompt = False
    Left = 872
    Top = 505
  end
  object FDQuery1: TFDQuery
    Active = True
    Connection = FDConnection1
    SQL.Strings = (
      'SELECT * FROM namedish'
      '')
    Left = 960
    Top = 505
  end
  object DataSource5: TDataSource
    DataSet = ADOQuery1
    Left = 1040
    Top = 456
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
    Left = 960
    Top = 456
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
    Left = 872
    Top = 456
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
      'Database=restaurantmenu'
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
    Left = 912
    Top = 624
  end
  object SQLQuery1: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      
        'SELECT menu.id, date, namedish.Name, typedish.Type, cost, count,' +
        ' VAT FROM menu, namedish, typedish  WHERE namedish.Id = menu.Nam' +
        'eDishId AND typedish.Id = menu.TypeDishId'
      '')
    SQLConnection = SQLConnection1
    Left = 1008
    Top = 624
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 872
    Top = 568
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 960
    Top = 568
  end
  object DataSource7: TDataSource
    DataSet = ClientDataSet1
    OnDataChange = DataSource1DataChange
    Left = 1040
    Top = 568
  end
end
