object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'LR'
  ClientHeight = 550
  ClientWidth = 1106
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
  object Label2: TLabel
    Left = 9
    Top = 376
    Width = 30
    Height = 13
    Caption = #1055#1086#1080#1089#1082
  end
  object DBGrid1: TDBGrid
    Left = 8
    Top = 8
    Width = 1094
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
        FieldName = 'id_kvit'
        Visible = False
      end
      item
        Expanded = False
        FieldName = 'Familiya'
        Width = 150
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Name'
        Width = 150
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Otchestvo'
        Width = 150
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Telefon'
        Width = 100
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'DomAdres'
        Width = 240
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'APYS'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'MTR'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'abonentplata'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'dataoplati'
        Visible = True
      end>
  end
  object DBLookupComboBox1: TDBLookupComboBox
    Left = 8
    Top = 287
    Width = 153
    Height = 21
    KeyField = 'Familiya'
    ListField = 'Familiya'
    ListSource = DataSource2
    TabOrder = 1
  end
  object Button1: TButton
    Left = 9
    Top = 314
    Width = 64
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 79
    Top = 314
    Width = 90
    Height = 25
    Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 3
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 175
    Top = 314
    Width = 58
    Height = 25
    Caption = #1059#1076#1072#1083#1080#1090#1100
    TabOrder = 4
    OnClick = Button3Click
  end
  object DBEdit1: TDBEdit
    Left = 32
    Top = 464
    Width = 33
    Height = 21
    DataField = 'id_kvit'
    DataSource = DataSource1
    TabOrder = 5
    Visible = False
  end
  object Button4: TButton
    Left = 382
    Top = 346
    Width = 75
    Height = 21
    Caption = 'Locate'
    TabOrder = 6
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 9
    Top = 345
    Width = 75
    Height = 25
    Caption = 'Lookup'
    TabOrder = 7
    OnClick = Button5Click
  end
  object Edit4: TEdit
    Left = 90
    Top = 347
    Width = 143
    Height = 21
    TabOrder = 8
  end
  object Edit5: TEdit
    Left = 247
    Top = 346
    Width = 130
    Height = 21
    TabOrder = 9
  end
  object DBLookupListBox1: TDBLookupListBox
    Left = 316
    Top = 400
    Width = 140
    Height = 134
    KeyField = 'abonentplata'
    ListField = 'abonentplata'
    ListSource = DataSource3
    TabOrder = 10
  end
  object Edit6: TEdit
    Left = 45
    Top = 373
    Width = 412
    Height = 21
    TabOrder = 11
    OnKeyPress = Edit6KeyPress
  end
  object DBGrid2: TDBGrid
    Left = 8
    Top = 400
    Width = 144
    Height = 134
    DataSource = DataSource2
    TabOrder = 12
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'Familiya'
        Visible = True
      end>
  end
  object Panel1: TPanel
    Left = 239
    Top = 328
    Width = 2
    Height = 42
    Caption = 'Panel1'
    TabOrder = 13
  end
  object DBNavigator1: TDBNavigator
    Left = 239
    Top = 314
    Width = 210
    Height = 25
    DataSource = DataSource1
    TabOrder = 14
  end
  object Button7: TButton
    Left = 198
    Top = 427
    Width = 74
    Height = 21
    Caption = #1054#1073#1085#1086#1074#1080#1090#1100
    TabOrder = 15
    OnClick = Button7Click
  end
  object DBLookupComboBox2: TDBLookupComboBox
    Left = 167
    Top = 287
    Width = 153
    Height = 21
    KeyField = 'id_norm'
    ListField = 'id_norm'
    ListSource = DataSource3
    TabOrder = 16
  end
  object DateTimePicker1: TDateTimePicker
    Left = 327
    Top = 287
    Width = 129
    Height = 21
    Date = 43469.000000000000000000
    Time = 0.754950532413204200
    TabOrder = 17
  end
  object Button6: TButton
    Left = 197
    Top = 464
    Width = 75
    Height = 21
    Caption = 'Excel'
    TabOrder = 18
    OnClick = Button6Click
  end
  object DBChart1: TDBChart
    Left = 463
    Top = 287
    Width = 635
    Height = 247
    Title.Text.Strings = (
      'TDBChart')
    TabOrder = 19
    DefaultCanvas = 'TGDIPlusCanvas'
    ColorPaletteIndex = 1
    object Series1: TLineSeries
      DataSource = SQLQuery4
      XLabelsSource = 'Familiya'
      Brush.BackColor = clDefault
      Pointer.InflateMargins = True
      Pointer.Style = psRectangle
      XValues.Name = 'X'
      XValues.Order = loAscending
      XValues.ValueSource = 'id_kvit'
      YValues.Name = 'Y'
      YValues.Order = loNone
      YValues.ValueSource = 'abonentplata'
    end
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
      'Database=laba19'
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
    Left = 32
    Top = 408
  end
  object SQLQuery1: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      
        'SELECT id_kvit, Familiya, Name, Otchestvo, Telefon, DomAdres, AP' +
        'YS, MTR, abonentplata, dataoplati FROM normi, vladelectelefona, ' +
        'kvitancia WHERE '
      
        'kvitancia.id_vladelec = vladelectelefona.id_vlad AND kvitancia.i' +
        'd_norma = normi.id_norm')
    SQLConnection = SQLConnection1
    Left = 128
    Top = 408
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    FieldDefs = <
      item
        Name = 'id_kvit'
        Attributes = [faRequired]
        DataType = ftInteger
      end
      item
        Name = 'Familiya'
        Attributes = [faRequired]
        DataType = ftString
        Size = 100
      end
      item
        Name = 'Name'
        Attributes = [faRequired]
        DataType = ftString
        Size = 100
      end
      item
        Name = 'Otchestvo'
        Attributes = [faRequired]
        DataType = ftString
        Size = 100
      end
      item
        Name = 'Telefon'
        Attributes = [faRequired]
        DataType = ftString
        Size = 100
      end
      item
        Name = 'DomAdres'
        Attributes = [faRequired]
        DataType = ftString
        Size = 200
      end
      item
        Name = 'APYS'
        Attributes = [faRequired]
        DataType = ftInteger
      end
      item
        Name = 'MTR'
        Attributes = [faRequired]
        DataType = ftInteger
      end
      item
        Name = 'abonentplata'
        Attributes = [faRequired]
        DataType = ftInteger
      end
      item
        Name = 'dataoplati'
        Attributes = [faRequired]
        DataType = ftDate
      end>
    IndexDefs = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    StoreDefs = True
    Left = 304
    Top = 408
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 216
    Top = 408
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    OnDataChange = DataSource1DataChange
    Left = 384
    Top = 408
  end
  object SQLQuery2: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT Familiya  FROM vladelectelefona')
    SQLConnection = SQLConnection1
    Left = 128
    Top = 456
  end
  object DataSetProvider2: TDataSetProvider
    DataSet = SQLQuery2
    Left = 216
    Top = 456
  end
  object ClientDataSet2: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider2'
    Left = 304
    Top = 456
  end
  object DataSource2: TDataSource
    DataSet = ClientDataSet2
    Left = 384
    Top = 456
  end
  object OpenDialog1: TOpenDialog
    Left = 448
    Top = 456
  end
  object SQLQuery3: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT *  FROM normi')
    SQLConnection = SQLConnection1
    Left = 128
    Top = 512
  end
  object DataSetProvider3: TDataSetProvider
    DataSet = SQLQuery3
    Left = 216
    Top = 512
  end
  object ClientDataSet3: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider3'
    Left = 304
    Top = 512
  end
  object DataSource3: TDataSource
    DataSet = ClientDataSet3
    Left = 384
    Top = 512
  end
  object ClientDataSet4: TClientDataSet
    Aggregates = <>
    FieldDefs = <
      item
        Name = 'id_kvit'
        Attributes = [faRequired]
        DataType = ftInteger
      end
      item
        Name = 'Familiya'
        Attributes = [faRequired]
        DataType = ftString
        Size = 100
      end
      item
        Name = 'Name'
        Attributes = [faRequired]
        DataType = ftString
        Size = 100
      end
      item
        Name = 'Otchestvo'
        Attributes = [faRequired]
        DataType = ftString
        Size = 100
      end
      item
        Name = 'Telefon'
        Attributes = [faRequired]
        DataType = ftString
        Size = 100
      end
      item
        Name = 'DomAdres'
        Attributes = [faRequired]
        DataType = ftString
        Size = 200
      end
      item
        Name = 'APYS'
        Attributes = [faRequired]
        DataType = ftInteger
      end
      item
        Name = 'MTR'
        Attributes = [faRequired]
        DataType = ftInteger
      end
      item
        Name = 'abonentplata'
        Attributes = [faRequired]
        DataType = ftInteger
      end
      item
        Name = 'dataoplati'
        Attributes = [faRequired]
        DataType = ftDate
      end>
    IndexDefs = <>
    Params = <>
    ProviderName = 'DataSetProvider4'
    StoreDefs = True
    Left = 304
    Top = 568
  end
  object SQLQuery4: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      
        'SELECT id_kvit, Familiya, Name, Otchestvo, Telefon, DomAdres, AP' +
        'YS, MTR, abonentplata, dataoplati FROM normi, vladelectelefona, ' +
        'kvitancia WHERE '
      
        'kvitancia.id_vladelec = vladelectelefona.id_vlad AND kvitancia.i' +
        'd_norma = normi.id_norm')
    SQLConnection = SQLConnection1
    Left = 128
    Top = 568
  end
  object DataSetProvider4: TDataSetProvider
    DataSet = SQLQuery4
    Left = 216
    Top = 568
  end
  object DataSource4: TDataSource
    DataSet = ClientDataSet4
    OnDataChange = DataSource1DataChange
    Left = 384
    Top = 568
  end
end
