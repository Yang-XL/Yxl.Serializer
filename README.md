���ϳ��õ����л���ʽ
ʹ�÷�ʽ
 _services.AddYxlSerializer(options =>
            {
                options.WithJson();
                options.WithMessagePack();
                options.WithProtobuf();
                options.WithSystemTextJson();
            });