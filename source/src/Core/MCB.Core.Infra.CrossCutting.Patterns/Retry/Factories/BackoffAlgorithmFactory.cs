﻿using MCB.Core.Infra.CrossCutting.Patterns.Factory.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Retry.Base;
using MCB.Core.Infra.CrossCutting.Patterns.Retry.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MCB.Core.Infra.CrossCutting.Patterns.Retry.Factories
{
    public class BackoffAlgorithmFactory
        : IFactory<BackoffAlgorithmBase>,
        IFactoryWithParameter<BackoffAlgorithmBase, BackoffAlgorithmTypeEnum>
    {
        public BackoffAlgorithmBase Create(CultureInfo culture)
        {
            return new DecorrJitterBackoffAlgorithm();
        }

        public BackoffAlgorithmBase Create(BackoffAlgorithmTypeEnum parameter, CultureInfo culture)
        {
            var backoffAlgorithm = Create(culture);

            switch (parameter)
            {
                case BackoffAlgorithmTypeEnum.Decorr:
                    backoffAlgorithm = new DecorrJitterBackoffAlgorithm();
                    break;
                case BackoffAlgorithmTypeEnum.EqualJitter:
                    backoffAlgorithm = new EqualJitterBackoffAlgorithm();
                    break;
                case BackoffAlgorithmTypeEnum.FullJitter:
                    backoffAlgorithm = new FullJitterBackoffAlgorithm();
                    break;
            }

            return backoffAlgorithm;
        }
    }
}
