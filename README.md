整合常用的序列化方式<br/>
使用方式<br/>
 _services.AddYxlSerializer(options =><br/>
            {<br/>
                options.WithJson();<br/>
                options.WithMessagePack();<br/>
                options.WithProtobuf();<br/>
                options.WithSystemTextJson();<br/>
            });<br/>
