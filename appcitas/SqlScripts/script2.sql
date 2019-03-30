﻿CREATE TABLE [dbo].[SGRC_Reversion] (
    [ReversionId] [uniqueidentifier] NOT NULL DEFAULT newsequentialid(),
    [NumeroTarjeta] [nvarchar](50) NOT NULL,
    [CIF] [nvarchar](25) NOT NULL,
    [Fecha] [datetime] NOT NULL,
    [Familia] [nvarchar](50) NOT NULL,
    [Segmento] [nvarchar](100) NOT NULL,
    [SegmentoId] [varchar](10) NOT NULL,
    [Marca] [nvarchar](50) NOT NULL,
    [MarcaId] [varchar](10) NOT NULL,
    [SaldoActual] [decimal](18, 2) NOT NULL,
    [Limite] [decimal](18, 2) NOT NULL,
    [TipoReversionId_1] [varchar](10),
    [TipoeReversion_1] [nvarchar](max),
    [Monto_1] [decimal](18, 2) NOT NULL,
    [FechaCargo_1] [datetime] NOT NULL,
    [TipoReversionId_2] [varchar](10),
    [TipoeReversion_2] [nvarchar](max),
    [Monto_2] [decimal](18, 2) NOT NULL,
    [FechaCargo_2] [datetime] NOT NULL,
    [TipoReversionId_3] [varchar](10),
    [TipoeReversion_3] [nvarchar](max),
    [Monto_3] [decimal](18, 2) NOT NULL,
    [FechaCargo_3] [datetime] NOT NULL,
    [TipoReversionId_4] [varchar](10),
    [TipoeReversion_4] [nvarchar](max),
    [Monto_4] [decimal](18, 2) NOT NULL,
    [FechaCargo_4] [datetime] NOT NULL,
    [TipoReversionId_5] [varchar](10),
    [TipoeReversion_5] [nvarchar](max),
    [Monto_5] [decimal](18, 2) NOT NULL,
    [FechaCargo_5] [datetime] NOT NULL,
    [TipoReversionId_6] [varchar](10),
    [TipoeReversion_6] [nvarchar](max),
    [Monto_6] [decimal](18, 2) NOT NULL,
    [FechaCargo_6] [datetime] NOT NULL,
    [Observacion] [nvarchar](max),
    CONSTRAINT [PK_dbo.SGRC_Reversion] PRIMARY KEY ([ReversionId])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201805292122555_ReversionChange1', N'appcitas.Migrations.Configuration',  0x1F8B0800000000000400ED3DDB6EE43A72EF01F20F8D7E4A16B36EBB7DC1C9C0DE85D73D3E30F6CCD870CF19E4CD90BBE91E256AA957520FC608F26579C827E51742DD285E8A5751528FCFC02F6E91AC228BC562B158C5FABFFFF9DFCBBF7EDF46936F28CDC224BE9A9E1C1D4F27285E25EB30DE5C4DF7F9CB9F7F99FEF52FFFFC4F971FD6DBEF932F4DBDD3A21E6E196757D3AF79BE7B3F9B65ABAF681B6447DB70952659F2921FAD92ED2C5827B3F9F1F1BFCD4E4E66088398625893C9E5E33ECEC32D2A7FE09F3749BC42BB7C1F441F93358AB2FA3B2E599650279F822DCA76C10A5D4D83DD6E15E618116E94A3EFF974721D8501EEC712452FD34910C7491EE4B897EF7FCFD0324F9378B3DCE10F41F4F9758770BD9720CA50DDFBF76D75D3811CCF8B81CCDA860DA8D53ECB93AD25C093D39A3233BEB9137DA7847298761F308DF3D762D425FDAEA6D731A670B80ED6D3098FEDFD4D94163529FA565371441ABD9B3445EF0823607E29FEDE4D6EF651BE4FD1558CF6791A44EF260FFBE7285CFD1DBD7E4EFE13C557F13E8AE8CEE1EEE132E603FEF490263B94E6AF8FE885EFF21DEEF48C0530E32190F650E36A74BFEE43FCFF27DC9BE03942841928422CF32445BFA218A5418ED60F419EA314CFE5DD1A95E4147AC1E1FCB4DFA234B9D9E3DA41831473215E4ED3C9C7E0FB6F28DEE45FAFA6E778FDDC86DFD1BAF95077E4F738C48B0FB7C9D33D023A6A82FC7390FE071A01FBCDDDAD02E7FCBC0F9CB768F5958C748167EC33162BF650826D8885C8E0145BA2CD16334AA2407C72DC2BE6766580B8FB40FD314857C393BAC43AC2683F87BB8492BB52ECF8DFDED18F31D909C5DE0BB40AB741349D3CA4F8BF5AE3F8653A59AE8202E0DC6DF52FD04D906E92CE42601944EBE47A556821BD75F8B7701BE6A837F0F7CF194ABF05AB527DE8CC6A1CAE4FC1B77053EE911CD64794E1DD1F6B22D974F288A2B24AF635DC552A59AB403CD1156FD364FB9844F42E4D953F2D937DBA2A0895282AE18D6E8372F38E7E09D2B0A066F6E15B10ED8375A0EB30D400EAB8584F3100A0323490CB59ABBF9969758432F7CF398AC375E2A4E6095046D1FBEE72B45DA047B48A826DE2A2FB0900E4826FFE4B1F92CF5CF954C3311982E38A56916C81B2551AEEFA11253201725D9C02833591E57F4BF0DA09623DCDA44B9EDA7A552B5D60FA27AA21B0E215F5E52B5FD5C88F0468444B23599C04000FE4D0CE7D60FDA6D30B547071BF874535338B3DF100EC2659871BE531C15088694E7049BC0E8B25FF5BB209954ABA9F85FF258892F4BA62B474206C8C82D71BAE6A4C0529094DAD85DA616C0443E3FB946C9F53340033542BAB2F745D77245E0A6B36247975F97EA468E3AA595B8EA96D6632A4E683C58848934EFB6BDB4DF3EDB46933CAEEC96F1BB67BA1F76DC771DBD32ECE793FD6B1FB34DCA0780473C922C8934212E6491A8F619B2BCC453ED09AAA483ECF188E3C769BA4DB7D3484AE53E12BB510CFD88C251956465EC28D8D1CAB5A8C22C52AD4770B7BF9D5B6945B997BB90129F1166CADB46FFB584315AAFBE7AC774C1F32FA480EC984FEF8F5C336CC921465361CDBB41985672BE42EE7CFB66535ACBB383F852CC0FEAE2A2B8CDAABCA1E6F8146D8E1F0CFF57E35C6959BFE92F1EDDDF5552CB6C4FCBA5709AA1E25C8ED3EAEF40B7301523719457ED4B85D1577AEF9D07A7B8D5EABB69FF6B4C26AF4A517C44390E28F799A643A896A04B4D08C89663EF83AAA151AD502EEC7BDA21A7CAF970152A3023D83805981143F9135DE5A1184426201688C06628DC6AC60DA3F8E25802E12DC6CCDB69B6005C1BE01D7EA64D220A3B7118CA4D128A2916077D1AE98C64329580469F1B3F703A6AFB3BB9B681AFCAC35F45627150344FA749751FCC2974B311B19A5E9595505EA5651A2E85359DC490AD5BC93A3ADBD49A2687550660955E5E226F087B36334BD1E47A0947742266A874F7B4A81F51AEBAEDF427C62493D78299A2235F3DC3235771FAE4187B9EAB359F44CC351D6BDD419A91F07A6115D9746F79D1ACE1349E1D458B328B07732DD7B2235DB2D14AC20ECA4702D67A7C6D68F02E832EB95F2C42DC3B6E7AA7AC2114A59193A4D198B0907017190A2E1A097B96F870B37F4E32CEF8257336A05F85BE5FC2251CB824EFE08D5BA73F14AA85A8EEA9BE0EEA967E961E7EF3CFF47778B30770FECE554E2DB5BB007FFBB37A3902905A75A6E7A5135785DC9482FF1E2ADC661825CD42455749DF6E38CF688EA686D3BE5A86E34927A5463775390A8C68306F1FE8CA3FD19477BC077EB7FAC38DA37109D59D8CB2969F674D2B79F658110118C4A7C7EAEA0CA68DF164F3FF1BE65B42F85C45558F1D3311F783A54F87C4EC77C88E9987B9F8ED381A74385CFE7749C0E311DA7DEA7E36CE0E950E1F3391D67434CC799F7E9381F783A54F87C4EC7F910D371EE7D3A2E069E0E153E9FD37131C4745C749E8EFEDEBD901DCBAFB32C5985E561938FEB53C592B3A3F810AF272E81E5D500D501EC78E4F843B8C3E777DCFDABE99F041A5A6227766D003B8FEC841D2846761F2F50847234C12A7CC93C3741B60AD6E2CC627AAFD92F8FE805A5C5B93D886E9238CBD3208C73D1E810C6AB7017440E43E26081260C753CFA8CA0E74B166887E2C2EAE030D11EFA45D07344D6D1F4724631B821DFD3CFBB68390D7CEBC580B38E8F8E4E4C38197A26C6C7BA71218C2294573B0E93B85E6058E243100ED2C0203EF8071306FA118D220BF493FC83890279A0B73DD389D6F5C1F85D30D853A8DB7B010301E5996BF97E9970873A24DC13DFF273E5A763836E62C0935FFACD46F5FE97CF4D4DF17498875561412FD1AF59D679859373DB632A1AC17CDD2A423C5AC8C4EDFAD0F62469EF4DD68C324ACC6A2D4BA7C74B370658B99C1FBB9E5958A7766F3CC838C353606917779E07BD6C1370174CA64FEEC8AEAA0EBAB23BF21C3D173DF4B88988198531E1D82F19236902C1B4024DC5A4EAF0B1217955D993436659E5F458F40460469564E5E20647E163D80D52C66B1ACFE796D738B720736ED6785DB61824B0C7DFFA952330E10E552482394F2BA7AA733706E04CA5A3998C7DCCBCCEC4735EE36B6BCEA866AEF4862B627CAE35194E47AE01EB6B0269AC58DE64F2471AC3F0EB456B93D1BA39F6B04A5C4C2E07B73646B6CF68E6ED408D32D53D5B91D407B740696398A9BD5549B21FC1E7F5F70CD56EAF597D81C7B35A01778972DED453BC2AD55EEE89361A81655938C2CD41B640546B3964E0CA41834A34FB18A2120D40A69800A8EDF2D300A974DD7D5ADEC782A09A67E8348016CFF8FFF60930014C5BA40154ABD3201072A0D2C0685F235920153CCA8EA08158C72031E49212AB92AB6610890E21C0E2740C2D8B97F5A0519A82200CD5EC0C52B66A2A68FB54FB4080C4A79CE3393894D4016481F2FD77AAA9CDBBF1BCC874BCED2704D08A1C41483BDEF053181961C9EF9D2C496DC8CD64025190577AA52CB18F0397CA6683D1C3038863351D5DC8A57A0B5A413DD37B67C3DB30256B6AB628136A1B5C37F7CF998A27AA6D280DEBD6AE379E3DD359D0B9217C5E973F9457472506749772F6D7729DC482E21ACE75AA1CC809BC2D24D2507351677855478D4AA20629E826BFA7A3C04A4175224CF5B4918A2AE2A591C9B591277A307746144C5831EC4C17C96B7422790CAE2E2C2E2F4C66D9E2BEA27F3A4902FF453A1998C62D8CE3E2C0244AB685399CD1561A65BE3381D411BE229DCC0DB5F6A65A48E0C247097BE3ACF18C74A7A14ACD30B2DB5959EEFC10CDB7DED0F85A131B1029BB9C5579A0EB0F973349C2E8CB8FC16E17C61B2A8174FD65B2ACB247DFFC79699F58795BC198AD18B583B758114C585E051BC49516669135BA0DD32C5F0479F01C148EE737EBAD508DB778498EC30D36D1A825CE5F73486EDA14FF57EDF864DA47D223424BCA5B3CBA22E6B51C28821429B1EDA4C8E41D4441CA39EE333E8B3749B4DFC606CE8C72786CF6651A205B620B9184828B20499139CC32C09B86547E306F5F076BD310EA4F16309A506D064AF3D11C4E1B7A4D036ABFDA43E25981FE6E0EAD8E8EA601D59F2C61F0DD211FCDE170398069685C91234CBE8F42A1C598136132EB4F96FC49D2F20A6C4A4A2C78838EFE6698832E3087D7447AD3A09A6FE65098B0231A145300DC10CE38512ADCAE08325BB8B662B701A34D426DAFF2B36D88971B1DF6110360B2A9116E5CE9E9D15EC7CAE1FADEB0243D74EA9BFCD544E9E0995A36BD1612B6B2BD178A0F6611A8AD327E168170EDD6610DE8610DC5AAE2B36B3450DDB36E26909BDB6608AEEC265A0E5578AD8CD1B8F8429BDE32CF90B19D658A6C6102FB1B53600E0F4C3F4AC3052B1C80D8F228AAC1ACA252D84D057BAE8540F3658727FEBA893A990DC240B2C99B0E2B1EBA4D9F5425249923197D907C358724A482A4010A85760707E8BCE0BA1948D40CB0823D7C929D11824D0AEDE1D6591821A875D1C12C59DE9DA6D3C2AD3D6FEC97ADACA162F7AD3DF5B96D57EA06AF86542555146139F217953E5184A939BE4937DD4C54852B804D02B483E129D6B3AA1347C9A018F094BCA994C4244922A3CC48922EEA21419642B664786BD103C95048036ABF8E67E3F363996373028A943FB8C5D2DE5A765A28920B788375226D299D78363093997E75CCA61626A42E7145F63085847D1074A192351EEEE21B40A209B892636837B6AEDB1D94720FE8A966DF1B69A9C0DE109D964DEB4F6BBF70146DA5D2974E14C7086079FA392378C54F09C4AA6868155EA9A18111967D889B911815741DF1A0599777E8AEDA35DC78280DBB099305A0595BF42439BC60D09D54782163178C83A9E282437AD723A9E2E3D850003D386D88F384E9B466949E4006CB46D3FECD582FBD5CE68C76EB58FB9D75E214771E19953B14D66767BBB38E270E9A1B7877332F56681896852D5A06E0AD5C85F563EBFE912ED80E49E48F2688DBC8B98EB2B809B27391C6D2B6F2A9A312C0B093274D2BA382F7D3A34F0DE7A7479FC1C80ED21F0D4830C29B08B8623BD86C2E111E345B6AE971C803241F2DD710490E222C2552E24ECFB99A9EF30EF40440B3A5B6F49C43F4B482C366F790D0D37ACC5C8A0F153D4F3BD01300CD96DAD2F314A2A7151C363D87849ED663E67274A8E879D6819E0068B6D4969E67103DADE0B0F93524F4B41E3397644345CFF30EF40440B3A5B6F43C87E86905874D9021A1A7F598B92C192A7A5E74A027009A2DB5A5E705444F2B386C860B093DAD201EAABF391BD125894C62DE7C30F1A2651AB8FB8817F16B32CF58E0C10891788ECEB54F4A37DBF2E5A906A6638FA5AF4BF5706A55F6B73CEB970F8DDD6545E6169258C59A307C7460077683DE1830623BA8A1B37BB6722EE5EF131C3A17CA5F40F0D67389EDA4177BDCC170B71002CB5721A2BCFE427E9310D83AFC94898B2DE95644B996F4CAEA50583E1EB5AA52A4784ABE85EB221675F99A618A1D15158E96FF886EA2106F1E6D858F411CBEA02CAFB2034FE7C727F838701D854156452ED791B6EFF937DB8C426F4F4E8BD05BB4DECEF8E6F601BC05942C5B33C98BC5CCCAB2B42C46398E95D3AECB71CC34AE9EB3DAC7E13FF6282C1316BF8428AD65902AA7B165D22C3622B6C21A7F0B52AC9BA442225927D85C02655FC0A9FCC820C822437297F4C76B4CDFDC43FA635FE3E5B31B8370CBFCC69D9317C390BBA526F645062EF3B0A7AE7201B86C97FF651B7CFFD76E20FDD336A158619BC4C87EE5B351B82DD3FB48CAECD62336F3B21B0C2009A0741ECD13FDC97709E01D4FE171D2BB788DBE5F4DFF6BF2DF2E7B8A462BD7EF2B0200950099FF624D72A37D4B4E9402C8FBC9DDBFD33AD3BBC97D8A558BF793634C33DBFE48476AC0001AEA31D7E91E800331B215D4E730779F8727EF336232373E5693F854ADE7C5A43E0889F575A7064F5ADD80AB431C91AC538E801BC7045ECA188C9105C10E532EA44C169AE088E061F1726E08DE20323B692778607CAFBB80E951B0F601B3F165F13231AC7B8C07903FAEB496A40C3092BF6AEF25BD34D509998EAA8C7A9ED9F3A5C351AB8D00F67A1810E280BD9F8D6C80DAAC271B7DCA6A024950B0C7C55F8704F777A880A26BCD9695CCDF5FBFA0DA96AA73BABD75460CCB55DA01AC390888D1ED0341E378AF92339E661F8E83359B7F59ECAB7EFEDB96D510C3C2B4EBDBC8C806D3FA37327997790F24CE5605D61E2E671B3C78131E1B8B5B81EE6D01C049648DF85F1960A65F045C73CF4A051718AB807EEAC252B2C0586A3DBB81E4C26039C63250489BBDE509024814D313FE74E77017C06D62FE3BC91F411D2E178088DDFE540949CCABD96A5204B9EAD712D3B8C73D858B9BF5A0E749145D731E5A3C55207A60ED85CF6E7963E60EA61E0682A9A507E89BA5722D46F87453B055951D0D865261E64121674D7E9E9404490C6F1FEAB810C46B7CB96887C3F45C31EF329001CF16DCE3FC9E8DEA2A8FB11EEEB3143759068287B4EE207486BF63F3780B65CC347012DD6E1CD169763BD2D0CE2C6C0372A0095105AADA995FDDAFB3CCAF8F7C2B7CA3DD2F1D82E558737FD55139B0BBC9EA76576427A49F38C13AACD0F6D253E110E04FA795C4D19ACA6869E0AC8994A61A0FEBABF8D39FF0A73FE1A1FB13022E716BB40AB7C5CF8714FF97950ED027581214AEECB878DED15BCE3B78204ED8E70DA0182BECC18243E2857BA2091B42DC715D0381C33D1278EE91C0F321083CF74EE0D35E097CEA91C0A74310F8D43B81CF7A25F09947029F0D41E033EF043EEF95C0E71E097C3E0481CFBD13F8A257025F7824F0C51004BEE84CE07EDCF1A9003ADE9B4E91DA5E48A228E4746EBAC8269EC64C804186BB081FC0F3D7C228CB1FAEEEE3058A508E2658E52B27E026C856C15AA44E1161A8ED05105200750BA8C6F6F34F027A7CF8436971F80AA29B24CEF23408C530F087348C57E12E8804EA7035C153A5DAC17A4680F3250BB443717130D453C3433708366E7A74046262370D39928E60F7C481C74747C213363F39A9674ED205510FC9537C9CC48F27E4C4480FA85762ADB7C898BAE7030E5DC209DC28F11017734833B3DE7E74937607C55230092473A9F68A1F90A9F41D1974E7141F98187A073D289EFAA1C5D4016C9FC465EC0976356DE7BF29A7679B7C1B64A36C1DF8E83E505F7BE13079761A4B9F5B2B0E5325F770C03B282715477C291B513E67F42CD29F796692CBA471384299D0C2C64F4E555DFA204F4F2CA44A6F02549765551984D56A767F62BDB107E1380B29F8C7E2361B3169D947B3145483701EE3D0F0047B83B5CC429C0B296621DF06D932392747AA1F5C492FAC2BCF4D61E73069CE85BABC29967807E028D679EC493180EED3DA1393713E78D0F9B529EA85CDBC4E3A58DFE01548631655792C0ED7DDE139DBAF01E48DB2F258261207A61CC12EC23D0149B409EEB94681C3EAD749F9E3F774D25EA589C691EAD1C7ABE9FAB990B0D575DCF2D7C79BF6D08E84EC63725CC07D821C395059DA9BF6266581A8DE9BF64B34D3C8BB25D695F64AB452D9F4AE5DF44267DA223D6E2D9EFA7101114B5320C5D154D02020F1EB228AB6488AA4AAA245428E1F020E522245D1A622D561A10ED5021EAA4C8A499E9F56322D9594954C4D55A8999EAA920619A73009F8B872294A36FB9F7E90728C7A5CC648F83D4BBA9C9A0AFA4555D534195FE3870D8D909429C648EA7098D8A7826D9C1D265453ADCC95DD1FCA4CECD023D8C0AE6876256DF6A0BBA0D9B0A4B1211BF3A6BC824CD29BFBB74916C5A5B28A4AA677D1FE8926DBCF358FB3F749B276CBB6A1984C13060F0CD418DB8F3F06B9C057F5550B507701F886784ABC9C0228A3B9C182ADB7D400C837052904E5874BA2EE73A8E5ED89729CE2FD8AD4DE4DF556AE130D3C54D87A0F8CD8C0CCEF71E016BCE13068D8700C0CDAC0C20CDB98A96E936F8AE1827A2F903BBAFBD095164E8002E616511F03529A7F807DA529F24D16D52E696449F3B435F6410221790729BB9C550780FA03FE2924E9B89C3DEEE3C2D1BAFAB54059B8694114494862B4622C45A4CE5DFC9234862BAE474D15DE911C614D32C883EB340F5F82558E8B5728CBC2189FF5BFE07DAD3CD33FA3F55D7CBFCF77FB1C0F196D9FA3579A1885E14B85FF7226F4F9F27E57FCCA7C0CE14BB91DE7E83EFEDB3E8CD6A4DFB74050AD04446151AB63548BB9CC8B58D5CD2B81F429890D01D5E42386C0CF68BB8B30B0EC3E5E06DF904BDF7ECFD06F6813AC5E1FEA5C2B7220FA8960C97EB908830DDEE7B21A46DB1EFFC43CBCDE7EFFCBFF037D9D0A7E1A1C0100 , N'6.2.0-61023')

