object Form3: TForm3
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  BorderStyle = bsSingle
  Caption = #1058#1077#1089#1090
  ClientHeight = 400
  ClientWidth = 756
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object PageControl1: TPageControl
    Left = -3
    Top = 0
    Width = 635
    Height = 270
    ActivePage = TabSheet1
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = #1042#1086#1087#1088#1086#1089' 1'
      ExplicitWidth = 631
      ExplicitHeight = 246
      object Image1: TImage
        Left = 496
        Top = 48
        Width = 49
        Height = 33
      end
      object RadioGroup1: TRadioGroup
        Left = 3
        Top = 3
        Width = 185
        Height = 180
        Caption = #1050#1072#1082' '#1085#1072#1079#1099#1074#1072#1077#1090#1089#1103' '#1085#1072#1096#1072' '#1043#1072#1083#1072#1082#1090#1080#1082#1072'?'
        Items.Strings = (
          #1057#1086#1083#1085#1077#1095#1085#1072#1103' '#1089#1080#1089#1090#1077#1084#1072
          #1052#1083#1077#1095#1085#1099#1081' '#1087#1091#1090#1100
          #1047#1074#1077#1079#1076#1085#1072#1103' '#1089#1080#1089#1090#1077#1084#1072
          #1050#1086#1089#1084#1080#1095#1077#1089#1082#1080#1081' '#1086#1073#1100#1077#1082#1090)
        TabOrder = 0
      end
    end
    object TabSheet2: TTabSheet
      Caption = #1042#1086#1087#1088#1086#1089' 2'
      ImageIndex = 1
      object Label1: TLabel
        Left = 16
        Top = 13
        Width = 3
        Height = 13
      end
      object Label4: TLabel
        Left = 16
        Top = 16
        Width = 277
        Height = 13
        Caption = #1050#1072#1082#1086#1077' '#1082#1086#1083#1080#1095#1077#1089#1090#1074#1086' '#1079#1074#1105#1079#1076' '#1085#1072#1089#1095#1080#1090#1099#1074#1072#1077#1090#1089#1103' '#1091' '#1043#1072#1083#1072#1082#1090#1080#1082#1080'?'
      end
      object CheckBox1: TCheckBox
        Left = 16
        Top = 32
        Width = 97
        Height = 17
        Caption = '3000 '#1084#1088#1076#1088'.'
        TabOrder = 0
      end
      object CheckBox2: TCheckBox
        Left = 16
        Top = 55
        Width = 97
        Height = 17
        Caption = '10 '#1090#1099#1089'.'
        TabOrder = 1
      end
      object CheckBox3: TCheckBox
        Left = 16
        Top = 78
        Width = 97
        Height = 17
        Caption = '1 '#1090#1099#1089'.'
        TabOrder = 2
      end
      object CheckBox4: TCheckBox
        Left = 16
        Top = 101
        Width = 97
        Height = 17
        Caption = #1073#1086#1083#1077#1077' 200 '#1084#1083#1088#1076'.'
        TabOrder = 3
      end
    end
    object TabSheet3: TTabSheet
      Caption = #1042#1086#1087#1088#1086#1089' 3'
      ImageIndex = 2
      object RadioGroup2: TRadioGroup
        Left = 0
        Top = 3
        Width = 600
        Height = 180
        Caption = #1057#1082#1086#1083#1100#1082#1086' '#1087#1083#1072#1085#1077#1090' '#1074' '#1089#1086#1083#1085#1077#1095#1085#1086#1081' '#1089#1080#1089#1090#1077#1084#1077'? '
        Items.Strings = (
          '3'
          '5'
          '2'
          '8')
        TabOrder = 0
      end
    end
    object TabSheet4: TTabSheet
      Caption = #1042#1086#1087#1088#1086#1089' 4'
      ImageIndex = 3
      object RadioGroup3: TRadioGroup
        Left = 0
        Top = 3
        Width = 600
        Height = 126
        Caption = 
          #1043#1072#1083#1072#1082#1090#1080#1082#1086#1081' '#1085#1072#1079#1099#1074#1072#1077#1090#1089#1103'  '#1089#1080#1089#1090#1077#1084#1072' '#1080#1079' '#1079#1074#1077#1079#1076', '#1084#1077#1078#1079#1074#1077#1079#1076#1085#1086#1075#1086' '#1075#1072#1079#1072' '#1080' '#1087#1099#1083 +
          #1080', '#1090#1077#1084#1085#1086#1081' '#1084#1072#1090#1077#1088#1080#1080'. '#1042#1077#1088#1085#1086' '#1083#1080' '#1101#1090#1086' '#1091#1090#1074#1077#1088#1078#1076#1077#1085#1080#1077':'
        Items.Strings = (
          #1044#1072
          #1053#1077#1090)
        TabOrder = 0
      end
    end
    object TabSheet5: TTabSheet
      Caption = #1042#1086#1087#1088#1086#1089' 5'
      ImageIndex = 4
      object Label2: TLabel
        Left = 240
        Top = 69
        Width = 97
        Height = 13
        Caption = #1052#1083#1077#1095#1085#1099#1081' '#1087#1091#1090#1100' '#1101#1090#1086':'
      end
      object Edit1: TEdit
        Left = 208
        Top = 88
        Width = 153
        Height = 21
        TabOrder = 0
      end
    end
    object TabSheet6: TTabSheet
      Caption = #1042#1086#1087#1088#1086#1089' 6'
      ImageIndex = 5
      object RadioGroup5: TRadioGroup
        Left = 0
        Top = 3
        Width = 505
        Height = 118
        Caption = #1043#1072#1083#1072#1082#1090#1080#1082#1080' '#1074#1088#1072#1097#1072#1102#1090#1089#1103' '#1074#1086#1082#1088#1091#1075':'
        Items.Strings = (
          #1057#1086#1083#1085#1094#1072
          #1055#1083#1072#1085#1077#1090
          #1054#1073#1097#1077#1075#1086' '#1094#1077#1085#1090#1088#1072' '#1090#1103#1078#1077#1089#1090#1080)
        TabOrder = 0
        TabStop = True
      end
    end
    object TabSheet7: TTabSheet
      Caption = #1042#1086#1087#1088#1086#1089' 7'
      ImageIndex = 6
      object RadioGroup6: TRadioGroup
        Left = 0
        Top = 3
        Width = 600
        Height = 180
        Caption = #1042' '#1095#1077#1084' '#1080#1079#1084#1077#1088#1103#1077#1090#1089#1103' '#1088#1072#1089#1089#1090#1086#1103#1085#1080#1077' '#1084#1077#1078#1076#1091' '#1075#1072#1083#1072#1082#1090#1080#1082#1072#1084#1080'?'
        Items.Strings = (
          #1043#1086#1076'    '
          #1042#1077#1082'       '
          #1057#1074#1077#1090#1086#1074#1086#1081' '#1075#1086#1076)
        TabOrder = 0
      end
    end
    object TabSheet8: TTabSheet
      Caption = #1042#1086#1087#1088#1086#1089' 8'
      ImageIndex = 7
      object RadioGroup8: TRadioGroup
        Left = 0
        Top = 3
        Width = 600
        Height = 180
        Caption = ' '#1050' '#1082#1072#1082#1086#1084#1091' '#1074#1080#1076#1091' '#1075#1072#1083#1072#1082#1090#1080#1082' '#1086#1090#1085#1086#1089#1080#1090#1089#1103' '#1085#1072#1096#1072' '#1043#1072#1083#1072#1082#1090#1080#1082#1072'?'
        Items.Strings = (
          #1069#1083#1083#1080#1087#1090#1080#1095#1077#1089#1082#1072#1103' '
          #1057#1087#1080#1088#1072#1083#1100#1085#1072#1103
          #1053#1077#1087#1088#1072#1074#1080#1083#1100#1085#1072#1103)
        TabOrder = 0
      end
    end
    object TabSheet9: TTabSheet
      Caption = #1042#1086#1087#1088#1086#1089' 9'
      ImageIndex = 8
      object RadioGroup9: TRadioGroup
        Left = 0
        Top = 3
        Width = 441
        Height = 180
        Caption = 
          #1042#1099#1073#1077#1088#1080#1090#1077' '#1087#1088#1072#1074#1080#1083#1100#1085#1086#1077' '#1091#1090#1074#1077#1088#1078#1076#1077#1085#1080#1077'.  '#1057#1091#1097#1077#1089#1090#1074#1091#1102#1090' '#1090#1088#1080' '#1086#1089#1085#1086#1074#1085#1099#1093' '#1074#1080#1076#1072'  ' +
          #1075#1072#1083#1072#1082#1090#1080#1082':'
        Items.Strings = (
          #1069#1083#1083#1080#1087#1090#1080#1095#1077#1089#1082#1080#1077', '#1089#1087#1080#1088#1072#1083#1100#1085#1099#1077', '#1085#1077#1087#1088#1072#1074#1080#1083#1100#1085#1099#1077'.'
          #1050#1088#1091#1075#1086#1074#1099#1077', '#1087#1088#1072#1074#1080#1083#1100#1085#1099#1077', '#1087#1072#1088#1072#1083#1083#1077#1083#1100#1085#1099#1077'.'
          #1064#1072#1088#1086#1086#1073#1088#1072#1079#1085#1099#1077', '#1089#1092#1077#1088#1080#1095#1077#1089#1082#1080#1077', '#1082#1086#1085#1091#1089#1086#1074#1080#1076#1085#1099#1077'.')
        TabOrder = 0
      end
    end
    object TabSheet10: TTabSheet
      Caption = #1042#1086#1087#1088#1086#1089' 10'
      ImageIndex = 9
      object RadioGroup7: TRadioGroup
        Left = 0
        Top = 3
        Width = 600
        Height = 180
        Caption = #1055#1088#1080#1084#1077#1088#1085#1086#1077' '#1082#1086#1083#1080#1095#1077#1089#1090#1074#1086' '#1075#1072#1083#1072#1082#1090#1080#1082' '#1074#1086' '#1042#1089#1077#1083#1077#1085#1085#1086#1081' '#1085#1072' '#1089#1077#1075#1086#1076#1085#1103#1096#1085#1080#1081' '#1076#1077#1085#1100'?'
        Items.Strings = (
          '500     '
          '300          '
          '1011')
        TabOrder = 0
      end
    end
    object TabSheet11: TTabSheet
      Caption = #1056#1077#1079#1091#1083#1100#1090#1072#1090
      ImageIndex = 10
      object Label3: TLabel
        Left = 88
        Top = 112
        Width = 7
        Height = 25
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -21
        Font.Name = 'Tahoma'
        Font.Style = []
        ParentFont = False
      end
    end
  end
  object Button2: TButton
    Left = 256
    Top = 210
    Width = 73
    Height = 55
    Caption = #1044#1072#1083#1077#1077
    TabOrder = 1
    OnClick = Button2Click
  end
end
