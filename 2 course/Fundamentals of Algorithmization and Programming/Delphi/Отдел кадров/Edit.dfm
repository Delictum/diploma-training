object FEditor: TFEditor
  Left = 0
  Top = 0
  Caption = 'FEditor'
  ClientHeight = 782
  ClientWidth = 864
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label17: TLabel
    Left = 509
    Top = 686
    Width = 154
    Height = 13
    Caption = #1055#1077#1088#1077#1084#1077#1097#1077#1085#1080#1077' '#1087#1086' '#1089#1086#1090#1088#1091#1076#1085#1080#1082#1072#1084
  end
  object GroupBox1: TGroupBox
    Left = 8
    Top = 0
    Width = 825
    Height = 217
    Caption = #1051#1080#1095#1085#1099#1077' '#1076#1072#1085#1085#1099#1077
    TabOrder = 0
    OnExit = GroupBox1Exit
    object Label1: TLabel
      Left = 6
      Top = 43
      Width = 44
      Height = 13
      Caption = #1060#1072#1084#1080#1083#1080#1103
    end
    object Label2: TLabel
      Left = 31
      Top = 70
      Width = 19
      Height = 13
      Caption = #1048#1084#1103
    end
    object Label3: TLabel
      Left = 3
      Top = 97
      Width = 49
      Height = 13
      Caption = #1054#1090#1095#1077#1089#1090#1074#1086
    end
    object Label4: TLabel
      Left = 31
      Top = 124
      Width = 19
      Height = 13
      Caption = #1055#1086#1083
    end
    object Label5: TLabel
      Left = 266
      Top = 43
      Width = 80
      Height = 13
      Caption = #1044#1072#1090#1072' '#1088#1086#1078#1076#1077#1085#1080#1103
    end
    object Label6: TLabel
      Left = 252
      Top = 70
      Width = 94
      Height = 13
      Caption = #1044#1072#1090#1072' '#1087#1086#1089#1090#1091#1087#1083#1077#1085#1080#1103
    end
    object Label7: TLabel
      Left = 549
      Top = 43
      Width = 69
      Height = 13
      Caption = #1050#1086#1083'-'#1074#1086' '#1076#1077#1090#1077#1081
    end
    object Label8: TLabel
      Left = 525
      Top = 70
      Width = 93
      Height = 13
      Caption = #1057#1090#1072#1078' '#1088#1072#1073#1086#1090#1099', '#1083#1077#1090
    end
    object Label9: TLabel
      Left = 551
      Top = 97
      Width = 67
      Height = 13
      Caption = #1054#1073#1088#1072#1079#1086#1074#1072#1085#1080#1077
    end
    object DBEdit1: TDBEdit
      Left = 56
      Top = 40
      Width = 121
      Height = 21
      DataField = #1060#1072#1084#1080#1083#1080#1103
      DataSource = FName.DSLichData
      TabOrder = 0
    end
    object DBEdit2: TDBEdit
      Left = 56
      Top = 67
      Width = 121
      Height = 21
      DataField = #1048#1084#1103
      DataSource = FName.DSLichData
      TabOrder = 1
    end
    object DBEdit3: TDBEdit
      Left = 56
      Top = 94
      Width = 121
      Height = 21
      DataField = #1054#1090#1095#1077#1089#1090#1074#1086
      DataSource = FName.DSLichData
      TabOrder = 2
    end
    object DBEdit4: TDBEdit
      Left = 352
      Top = 40
      Width = 121
      Height = 21
      DataField = #1044#1072#1090#1072'_'#1056#1086#1078#1076
      DataSource = FName.DSLichData
      TabOrder = 3
    end
    object DBEdit5: TDBEdit
      Left = 352
      Top = 67
      Width = 121
      Height = 21
      DataField = #1044#1072#1090#1072'_'#1055#1086#1089#1090
      DataSource = FName.DSLichData
      TabOrder = 4
    end
    object DBEdit6: TDBEdit
      Left = 624
      Top = 40
      Width = 121
      Height = 21
      DataField = #1044#1077#1090#1077#1081
      DataSource = FName.DSLichData
      TabOrder = 5
    end
    object DBEdit7: TDBEdit
      Left = 624
      Top = 67
      Width = 121
      Height = 21
      DataField = #1057#1090#1072#1078
      DataSource = FName.DSLichData
      TabOrder = 6
    end
    object DBEdit8: TDBEdit
      Left = 624
      Top = 94
      Width = 121
      Height = 21
      DataField = #1054#1073#1088#1072#1079#1086#1074#1072#1085#1080#1077
      DataSource = FName.DSLichData
      TabOrder = 7
    end
    object DBComboBox1: TDBComboBox
      Left = 56
      Top = 121
      Width = 121
      Height = 21
      DataField = #1055#1086#1083
      DataSource = FName.DSLichData
      Items.Strings = (
        #1052#1091#1078
        #1046#1077#1085)
      TabOrder = 8
    end
    object DBCheckBox1: TDBCheckBox
      Left = 624
      Top = 123
      Width = 97
      Height = 17
      Caption = #1046#1077#1085#1072#1090'/'#1047#1072#1084#1091#1078#1077#1084
      DataField = #1057#1077#1084'_'#1055#1086#1083#1086#1078
      DataSource = FName.DSLichData
      TabOrder = 9
    end
    object DBCheckBox2: TDBCheckBox
      Left = 624
      Top = 146
      Width = 97
      Height = 17
      Caption = #1042#1086#1077#1085#1085#1086#1086#1073#1103#1079#1072#1085#1085#1099#1081
      DataField = #1042#1086#1077#1085#1085#1086#1086#1073#1103#1079#1072#1085#1085#1099#1081
      DataSource = FName.DSLichData
      TabOrder = 10
    end
  end
  object GroupBox2: TGroupBox
    Left = 8
    Top = 223
    Width = 825
    Height = 105
    Caption = #1044#1086#1083#1078#1085#1086#1089#1090#1100
    TabOrder = 1
    OnExit = GroupBox1Exit
    object Label10: TLabel
      Left = 17
      Top = 42
      Width = 33
      Height = 13
      Caption = #1054#1090#1076#1077#1083
    end
    object Label11: TLabel
      Left = 288
      Top = 42
      Width = 57
      Height = 13
      Caption = #1044#1086#1083#1078#1085#1086#1089#1090#1100
    end
    object DBEdit9: TDBEdit
      Left = 56
      Top = 40
      Width = 121
      Height = 21
      DataField = #1054#1090#1076#1077#1083
      DataSource = FName.DSDoljnost
      TabOrder = 0
    end
    object DBEdit10: TDBEdit
      Left = 352
      Top = 40
      Width = 121
      Height = 21
      DataField = #1044#1086#1083#1078#1085#1086#1089#1090#1100
      DataSource = FName.DSDoljnost
      TabOrder = 1
    end
  end
  object GroupBox3: TGroupBox
    Left = 8
    Top = 334
    Width = 825
    Height = 105
    Caption = #1044#1086#1084#1072#1096#1085#1080#1081' '#1072#1076#1088#1077#1089
    TabOrder = 2
    OnExit = GroupBox1Exit
    object Label12: TLabel
      Left = 13
      Top = 40
      Width = 37
      Height = 13
      Caption = #1057#1090#1088#1072#1085#1072
    end
    object Label13: TLabel
      Left = 19
      Top = 67
      Width = 31
      Height = 13
      Caption = #1040#1076#1088#1077#1089
    end
    object Label14: TLabel
      Left = 315
      Top = 40
      Width = 31
      Height = 13
      Caption = #1043#1086#1088#1086#1076
    end
    object DBEdit11: TDBEdit
      Left = 56
      Top = 37
      Width = 121
      Height = 21
      DataField = #1057#1090#1088#1072#1085#1072
      DataSource = FName.DSAdress
      TabOrder = 0
    end
    object DBEdit12: TDBEdit
      Left = 56
      Top = 64
      Width = 233
      Height = 21
      DataField = #1044#1086#1084'_'#1040#1076#1088#1077#1089
      DataSource = FName.DSAdress
      TabOrder = 1
    end
    object DBEdit13: TDBEdit
      Left = 352
      Top = 37
      Width = 121
      Height = 21
      DataField = #1043#1086#1088#1086#1076
      DataSource = FName.DSAdress
      TabOrder = 2
    end
  end
  object GroupBox4: TGroupBox
    Left = 8
    Top = 445
    Width = 825
    Height = 212
    Caption = #1058#1077#1083#1077#1092#1086#1085#1099
    TabOrder = 3
    OnExit = GroupBox1Exit
    object Label15: TLabel
      Left = 6
      Top = 27
      Width = 44
      Height = 13
      Caption = #1058#1077#1083#1077#1092#1086#1085
    end
    object Label16: TLabel
      Left = 285
      Top = 27
      Width = 61
      Height = 13
      Caption = #1055#1088#1080#1084#1077#1095#1072#1085#1080#1077
    end
    object DBEdit14: TDBEdit
      Left = 56
      Top = 24
      Width = 117
      Height = 21
      DataField = #1058#1077#1083#1077#1092#1086#1085
      DataSource = FName.DSTelephones
      MaxLength = 13
      TabOrder = 0
    end
    object Button1: TButton
      Left = 543
      Top = 24
      Width = 75
      Height = 25
      Caption = #1044#1086#1073#1072#1074#1080#1090#1100
      TabOrder = 1
      OnClick = Button1Click
    end
    object DBGrid1: TDBGrid
      Left = 3
      Top = 72
      Width = 819
      Height = 137
      DataSource = FName.DSTelephones
      TabOrder = 2
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'Tahoma'
      TitleFont.Style = []
    end
  end
  object DBComboBox2: TDBComboBox
    Left = 360
    Top = 469
    Width = 145
    Height = 21
    DataField = #1055#1088#1080#1084#1077#1095#1072#1085#1080#1077
    DataSource = FName.DSTelephones
    Items.Strings = (
      #1056#1072#1073#1086#1095#1080#1081' '
      #1044#1086#1084#1072#1096#1085#1080#1081
      #1052#1086#1073#1080#1083#1100#1085#1099#1081)
    TabOrder = 4
  end
  object DBNavigator1: TDBNavigator
    Left = 669
    Top = 680
    Width = 164
    Height = 25
    DataSource = FName.DSLichData
    VisibleButtons = [nbFirst, nbPrior, nbNext, nbLast]
    TabOrder = 5
  end
  object Button2: TButton
    Left = 8
    Top = 681
    Width = 105
    Height = 25
    Caption = #1057#1086#1093#1088#1072#1085#1080#1090#1100' '#1080' '#1074#1099#1081#1090#1080
    TabOrder = 6
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 168
    Top = 681
    Width = 121
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100' '#1089#1086#1090#1088#1091#1076#1085#1080#1082#1072
    TabOrder = 7
    OnClick = Button3Click
  end
end
