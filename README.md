整合常用的序列化方式
使用方式
 _services.AddYxlSerializer(options =>
            {
                options.WithJson();
                options.WithMessagePack();
                options.WithProtobuf();
                options.WithSystemTextJson();
            });